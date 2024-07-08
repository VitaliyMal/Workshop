namespace Workshop.Core
{
    /// <summary>
    /// Ингредиент
    /// </summary>
    public class Ingredient
    {
        public Ingredient(int id, string title="", int amount=0, int minimalAmount=0, int cost=0, IngredientType type=0)
        {
            Id = id;
            Title = title;
            Amount = amount;
            MinimalAmount = minimalAmount;
            Cost = cost;
            Type = type;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public int MinimalAmount{ get; set; }
        public int Cost { get; set; }
        public IngredientType Type { get; set; }
    }

    public enum IngredientType
    {
        Leather,
        Metal

    }
}