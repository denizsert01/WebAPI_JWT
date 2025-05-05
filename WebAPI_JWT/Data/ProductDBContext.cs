using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI_JWT.Models;

namespace WebAPI_JWT.Data
{
    public class ProductDBContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public ProductDBContext(DbContextOptions options) : base(options)
        {
        }

        protected ProductDBContext()
        {
        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var user1 = new AppUser
            {
                Id = 1,
                UserName = "superUser",
                NormalizedUserName = "SUPERUSER",
                Email = "super@user.com",
                NormalizedEmail = "SUPER@USER.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };

            var user2 = new AppUser
            {
                Id = 2,
                UserName = "cevdo",
                NormalizedUserName = "CEVDO",
                Email = "cevdo@deneme.com",
                NormalizedEmail = "CEVDO@DENEME.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };

            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            user1.PasswordHash = ph.HashPassword(user1, "spR_123");
            user2.PasswordHash = ph.HashPassword(user2, "ceVdo_123");
            builder.Entity<AppUser>().HasData(user1, user2);


            // Birkaç tane de product sisteme girelim
            var product1 = new Product
            {
                ProductID = 1,
                Name = "T-Shirt",
                Price = 400,
                Description = "Pamuk",
                
            };

            var product2 = new Product
            {
                ProductID = 2,
                Name = "Gomlek",
                Price = 600,
                Description = "Kısa kollu",

            };

            var product3 = new Product
            {
                ProductID = 3,
                Name = "Kazak",
                Price = 1200,
                Description = "Yun kazak V yaka",

            };

            var product4 = new Product
            {
                ProductID = 4,
                Name = "Ceket",
                Price = 4000,
                Description = "Yazlık suni deri ceket",

            };

            builder.Entity<Product>().HasData(product1, product2, product3, product4);
        }
    }
}
