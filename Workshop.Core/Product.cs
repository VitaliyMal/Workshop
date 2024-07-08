using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Workshop.Core
{
    /// <summary>
    /// Изделие
    /// </summary>
    public class Product
    {
        public Product(int id, string name="", string description = "", int price=0, int production_time = 0, List<Ingredient> ingredients=null) 
        {  
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Production_time = production_time;
            Ingredients= ingredients;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public int Production_time { get; set; }

        public List<Ingredient> Ingredients { get; set; }
    }
}
