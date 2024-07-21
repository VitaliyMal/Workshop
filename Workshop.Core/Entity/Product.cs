using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Workshop.Core.Entity
{
    /// <summary>
    /// Изделие
    /// </summary>
    public class Product( string name = "", string description = "", int price = 0, int production_time = 0, List<Ingredient> ingredients = null)
    {
        public static int _idCounter = 0;

        [JsonProperty("Id")]
        public int Id { get; set; } = _idCounter;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public int Price { get; set; } = price;

        public int Production_time { get; set; } = production_time;

        public List<Ingredient> Ingredients { get; set; } = ingredients;

        public override string ToString()
        {
            return string.Join(",", Convert.ToString(Id), Name, Description, Convert.ToString(Price), Convert.ToString(Production_time), Convert.ToString(Ingredients));
        }
    }
}
