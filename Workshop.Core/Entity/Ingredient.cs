using Newtonsoft.Json;
using System.Xml.Linq;

namespace Workshop.Core.Entity
{
    /// <summary>
    /// Ингредиент
    /// </summary>
    public class Ingredient(string title = "", int amount = 0, int minimalAmount = 0, int cost = 0, IngredientType type = 0)
    {
        public static int _idCounter = 0;

        [JsonProperty("Id")]
        public int Id { get; set; } = _idCounter;
        public string Title { get; set; } = title;
        public int Amount { get; set; } = amount;
        public int MinimalAmount { get; set; } = minimalAmount;
        public int Cost { get; set; } = cost;
        public IngredientType Type { get; set; } = type;

        
        public override string ToString()
        {
            return string.Join(",", Convert.ToString(Id), Title, Convert.ToString(Amount), Convert.ToString(MinimalAmount), Convert.ToString(Cost), Convert.ToString(Type));
        }
    }

    public enum IngredientType
    {
        Not_defined,
        Leather,
        Metal,
        Clay,
        Color
    }
}