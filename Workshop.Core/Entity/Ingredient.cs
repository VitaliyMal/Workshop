using System.Xml.Linq;

namespace Workshop.Core.Entity
{
    /// <summary>
    /// Ингредиент
    /// </summary>
    public class Ingredient(int id, string title = "", int amount = 0, int minimalAmount = 0, int cost = 0, IngredientType type = 0)
    {

        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public int Amount { get; set; } = amount;
        public int MinimalAmount { get; set; } = minimalAmount;
        public int Cost { get; set; } = cost;
        public IngredientType Type { get; set; } = type;

        
        public override string ToString()
        {
            return string.Join(",", Convert.ToString(Id), Title, Amount, MinimalAmount, Cost, Type);
        }
    }

    public enum IngredientType
    {
        Leather,
        Metal,
        Clay,
        Color
    }
}