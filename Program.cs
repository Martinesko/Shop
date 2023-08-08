using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Microsoft.AspNetCore.Identity;
using Shop.Data.Models;
using Shop.Services.CategoryService;
using Shop.Services.CategoryService.Contracts;
using Shop.Services.ProductService;
using Shop.Services.ProductService.Contract;
using Shop.Services.ShopService;
using Shop.Services.ShopService.Contract;


namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<CustomUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ShopDbContext>();
            
            builder.Services.AddScoped<ICategoryService,CategoryService>();
            builder.Services.AddScoped<IProductService,ProductService>();
            builder.Services.AddScoped<IShopService,ShopService>();
            builder.Services.AddScoped<IDetailsService,DetailsService>();

            builder.Services.AddControllersWithViews();

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
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}