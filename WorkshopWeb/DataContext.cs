using Microsoft.EntityFrameworkCore;
using WorkshopWeb.Entity;

namespace WorkshopWeb
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {            
        }

        public DbSet<Ingredient_Type> Ingredient_Type { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; } ///////THIS creat class and controller for each entity

        //public DbSet<Order> Order { get; set; }

        //public DbSet<Customer> Customer { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}
