using Microsoft.EntityFrameworkCore;

namespace WebdevelopmentDemo.Models
{
    public class DbContextClass  : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass>option): base(option) 
        {
                
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.Entity<User>().HasData(
               new User() { Id = 1, FirstName = "Gaurav", LastName = "Mori", EmailAddress = "gaurav@gmail.com", Password = "Mori@123", Mobile = "9090909090", RoleId = 1 },
               new User() { Id = 1, FirstName = "Jaya", LastName = "Prajapati", EmailAddress = "gaurav@gmail.com", Password = "Mori@123", Mobile = "9090909090", RoleId = 1 }


           );


            modelBuilder.Entity<Role>().HasData(
               new Role() { RoleId = 1, RoleName = "Admin" },
                new Role() { RoleId = 2, RoleName = "User" }
           );

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);


            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders);
        }
         

    }
}
