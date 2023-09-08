using HarvestHub.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Context
{
    public class AppDBContext : IdentityDbContext<User, IdentityRole, string>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>()
               .HasOne(a => a.User)
               .WithMany(u => u.Addresses)
               .HasForeignKey(a => a.UserName) 
               .HasPrincipalKey(u => u.UserName); 

            modelBuilder.Entity<Order>()
               .HasOne(a => a.User)
               .WithMany(u => u.Orders)
               .HasForeignKey(a => a.UserName) 
               .HasPrincipalKey(u => u.UserName);
        }
    }
}
