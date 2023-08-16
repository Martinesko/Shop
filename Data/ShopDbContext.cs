using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Shop.Data.Models;
using Shop.Data.Models.Products;

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
        public DbSet<Make> Makes { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<ImageUrl> ImgUrls { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ImageUrlProduct> ProductsImgUrls { get; set; } = null!;
        public DbSet<ModelType> ModelTypes { get; set; } = null!;
        public DbSet<Size> Sizes { get; set; } = null!;

        //Order
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomUser>(x => x.Property(x => x.AddressId).IsRequired(false));

            builder.Entity<Product>(x => x.Property(x => x.ColorId).IsRequired(true));

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
             builder
                .Entity<Make>()
                .HasData(new Make()
                    {
                        Id = 1,
                        Name = "Adidas"
                    }, new Make()
                    {
                        Id = 2,
                        Name = "Nike"
                    }, new Make()
                    {
                        Id = 3,
                        Name = "Puma"
                    }, new Make()
                    {
                        Id = 4,
                        Name = "Diesel"
                    }, new Make()
                    {
                        Id = 5,
                        Name = "Armani"
                    }
                );
             builder
                .Entity<ModelType>()
                .HasData(new ModelType()
                    {
                        Id = 1,
                        Name = "Slim"
                    }, new ModelType()
                    {
                        Id = 2,
                        Name = "Over sized"
                    }, new ModelType()
                    {
                        Id = 3,
                        Name = "Regular"
                    }
                );
             builder
                .Entity<Color>()
                .HasData(new Color()
                    {
                        Id = 1,
                        Name = "Red"
                    }, new Color()
                    {
                        Id = 2,
                        Name = "Black"
                    }, new Color()
                    {
                        Id = 3,
                        Name = "White"
                    }
                );
            
             builder
                .Entity<Size>()
                .HasData(new Size()
                    {
                        Id = 1,
                        Name = "XS"
                    }, new Size()
                    {
                        Id = 2,
                        Name = "S"
                    }, new Size()
                    {
                        Id = 3,
                        Name = "M"
                    }, new Size()
                    {
                        Id = 4,
                        Name = "L"
                    }, new Size()
                    {
                        Id = 5,
                        Name = "XL"
                    }, new Size()
                    {
                        Id = 6,
                        Name = "XXL"
                    }, new Size()
                    {
                        Id = 7,
                        Name = "One Size Fit All"
                    }
                );
            



            Assembly configAssembly = Assembly.GetAssembly(typeof(ShopDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);

        }
    }

}
