namespace WorkshopWeb.Entity
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public int MinimalAmount { get; set; }
        public int Cost { get; set; }

        public int IngredientType_id { get; set; }
        public Ingredient_Type? Ingredient_Type { get; set; } /// need in mapper and DTO?

    }
}
