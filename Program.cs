using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Microsoft.AspNetCore.Identity;
using Shop.Data.Models;
using Shop.Services.OrderService;
using Shop.Services.OrderService.Contract;
using Shop.Services.ProductService;
using Shop.Services.ProductService.Contract;
using Shop.Services.ProfileService;
using Shop.Services.ProfileService.Contract;
using Shop.Services.ShoppingCartService;
using Shop.Services.ShoppingCartService.Contract;
using Shop.Services.ShopService;
using Shop.Services.ShopService.Contract;
using Shop.Services.UsersService;
using Shop.Services.UsersService.Contract;


namespace Shop
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("ShopDatabaseConnection");
            builder.Services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<CustomUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole<Guid>>().AddEntityFrameworkStores<ShopDbContext>();


            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IShopService, ShopService>();
            builder.Services.AddScoped<IDetailsService, DetailsService>();
            builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
            builder.Services.AddScoped<IUsersService, UsersService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();

            builder.Services.AddControllersWithViews();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();
            app.UseStatusCodePagesWithReExecute("/Error/Error404/");


            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                    name: "areas",
                    pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                config.MapControllerRoute(
                    name: "ProtectingUrlRoute",
                    pattern: "/{controller}/{action}/{id}/{information}",

                    defaults: new { Controller = "Home", Action = "Index" });

                config.MapDefaultControllerRoute();

                config.MapRazorPages();
            });

            using (var scope = app.Services.CreateScope())
            {
                var roleManager =
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                var roles = new[] { "Admin", "User" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole<Guid>(role));
                    }
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<CustomUser>>();


                const string email = "admin@abv.bg";
                const string password = "Admin12!";
                Address address = new Address()
                {

                    City = "Kystendil",
                    CountryId = 1,
                    PostCode = "2500",
                    Street1 = "hello",
                    StreetNumber = "2"
                };

                if (await userManager.FindByEmailAsync(email) == null)
                {

                    var user = new CustomUser();
                    user.UserName = email;
                    user.Email = email;
                    user.Address = address;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            app.Run();
        }
    }
}