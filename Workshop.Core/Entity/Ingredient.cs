using Newtonsoft.Json;
using System.Xml.Linq;

namespace Workshop.Core.Entity
{
    /// <summary>
    /// Ингредиент
    /// </summary>
    public class Ingredient
    {
        public Ingredient(string title = "", int amount = 0, int minimalAmount = 0, int cost = 0, IngredientType type = IngredientType.Not_defined)
        {
            Id=_idCounter++;
            Title=title;
            Amount=amount;
            MinimalAmount=minimalAmount;
            Cost=cost;
            Type=type;
        }

        public Ingredient()
        {
            Id = _idCounter++;
            Title = "no_title";
            Amount = 0;
            MinimalAmount = 0;
            Cost = 0;
            Type = IngredientType.Not_defined;
        }
        public static int _idCounter = 0;

        [JsonProperty("Id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public int MinimalAmount { get; set; }
        public int Cost { get; set; }
        public IngredientType Type { get; set; }

        
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