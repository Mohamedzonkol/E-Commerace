using e_commerce.Configrution;
using e_commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Configrution
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
       //protected override void OnModelCreating(ModelBuilder builder)
       //{
       //    base.OnModelCreating(builder);
       //    builder.ApplyConfigurationsFromAssembly(typeof(CatagoryConfig).Assembly);
       //}
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OrderDeteils> OrderDeteils { get; set; }
        public DbSet<Product> Products { get; set; }

      

      

    }
}
