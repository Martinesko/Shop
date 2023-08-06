using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Shop.Data.Models;

namespace Shop.Data
{
    public class ShopDbContext : IdentityDbContext<CustomUser, IdentityRole<Guid>, Guid>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        //Address
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;

        //Product
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<ImageUrl> ImgUrls { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ImageUrlProduct> ProductsImgUrls { get; set; } = null!;
        public DbSet<ModelType> ModelTypes { get; set; } = null!;

        //Order
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrdersStatuses { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomUser>(x => x.Property(x => x.AddressId).IsRequired(false));

            builder.Entity<Product>(x => x.Property(x => x.ColorId).IsRequired(false));

            builder.Entity<ImageUrlProduct>(x =>
                x.HasKey(x => new { x.ProductId, x.ImageUrlId })
            );

            builder
                .Entity<Category>()
                .HasData(new Category()
                    {
                        Id = 1,
                        Name = "Pants"
                    }, new Category()
                    {
                        Id = 2,
                        Name = "T-shirt"
                    }, new Category()
                    {
                        Id = 3,
                        Name = "Underwear"
                    }, new Category()
                    {
                        Id = 4,
                        Name = "Jeans"
                    }, new Category()
                    {
                        Id = 5,
                        Name = "Trousers"
                    }
                );



            Assembly configAssembly = Assembly.GetAssembly(typeof(ShopDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);

        }
    }

}
