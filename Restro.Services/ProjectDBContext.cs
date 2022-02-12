using Microsoft.EntityFrameworkCore;
using Restro.Models;

namespace Restro.Services
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MyCart> MyCart { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}