using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Workshop.Core.Entity
{
    /// <summary>
    /// Изделие
    /// </summary>
    public class Product
    {
        public Product(string name = "", string description = "", int price = 0, int production_time = 0, List<Ingredient> ingredients = null)
        {
            Id=_idCounter++;
            Name=name;
            Description=description;
            Price=price;
            Production_time=production_time;
            Ingredients= ingredients;
        }

        public Product()
        {
            Id = _idCounter++;
            Name = "no_name";
            Description = "no_description";
            Price = 0;
            Production_time = 0;
            Ingredients = null;
        }
        public static int _idCounter = 0;

        [JsonProperty("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public int Production_time { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public override string ToString()
        {
            return string.Join(",", Convert.ToString(Id), Name, Description, Convert.ToString(Price), Convert.ToString(Production_time), Convert.ToString(Ingredients));
        }
    }
}
