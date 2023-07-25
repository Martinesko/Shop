using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Reflection;
using Shop.Data.Models;

namespace Shop.Data
{
    public class ShopDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        //Address
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;

        //Product
        public DbSet<Models.Color> Colors { get; set; } = null!;
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
            builder.Entity<User>(x => x.Property(x => x.AddressId).IsRequired(false));

            builder.Entity<Product>(x => x.Property(x => x.ColorId).IsRequired(false));

            builder.Entity<ImageUrlProduct>(x =>
                x.HasKey(x => new { x.ProductId, x.ImageUrlId })
            );

            Assembly configAssembly = Assembly.GetAssembly(typeof(ShopDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);

        }
    }

}
