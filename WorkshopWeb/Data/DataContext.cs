using Microsoft.EntityFrameworkCore;
using Workshop.Server.Entity;
using WorkshopWeb.Entity;

namespace Workshop.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Ingredient_Type> Ingredient_Type { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; } /*= default!;*/
        public DbSet<Order> Order { get; set; } /*= default!;*/
        public DbSet<Recipe> Recipe { get; set; } /*= default!;*/
        public DbSet<User> Users { get; set; }
        //public DbSet<SecurityResponse> SecurityResponse { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ingredient_Type>().HasData(new List<Ingredient_Type> {
                new Ingredient_Type
                {
                    Id = 1,
                    IngredientTypeTitle = "Not_defined"
                },

                new Ingredient_Type
                {
                    Id = 2,
                    IngredientTypeTitle = "Leather"
                },

                new Ingredient_Type
                {
                    Id = 3,
                    IngredientTypeTitle = "Metal"
                },

                new Ingredient_Type
                {
                    Id = 4,
                    IngredientTypeTitle = "Clay"
                },

                new Ingredient_Type
                {
                    Id = 5,
                    IngredientTypeTitle = "Color"
                }
            }
            );


            modelBuilder.Entity<State_Type>().HasData(new List<State_Type> {
                new State_Type
                {
                    Id= 1,
                    State_Type_Title= "ToDo"
                },

                new State_Type
                {
                    Id = 2,
                    State_Type_Title = "InProgress"
                },

                new State_Type
                {
                    Id = 3,
                    State_Type_Title = "Ready"
                },

                new State_Type
                {
                    Id = 4,
                    State_Type_Title = "Canceled"
                }
            }
            );
        }

    }
}
