using WorkshopWeb.Entity;

namespace Workshop.Server.Entity
{
    public class Recipe
    {
        public int Id { get; set; }

        public int Id_Ingredient { get; set; }
        public Ingredient? Ingredient { get; set; }

        public int Id_Product { get; set; }
        public Product? Product { get; set; }

    }
}
