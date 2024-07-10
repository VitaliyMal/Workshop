using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.Entity;
using Workshop.Core.Utility;

namespace Workshop.Core.Data
{
    public class IngredientDataSource
    {
        private readonly string path = ".\\Ingredient.json";

        /// <summary>
        /// Метод чтения в формате JSON и их десериализация
        /// </summary>

        public List<Ingredient> Get()
        {
            if (File.Exists(path))
            {
                string ingredientF = File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Ingredient>>(ingredientF);
            }
            return null;
        }

        /// <summary>
        /// Метод записи в формате JSON и их сериализация
        /// </summary>

        public void Write(List<Ingredient> ingredientF)
        {
            File.WriteAllText(path, DataSerializer.Serialize(ingredientF));
        }



        /// <summary>
        /// Принимает не лист, а один экземпляр класса.
        /// </summary>
        /// <returns></returns>
        //public Ingredient Get()
        //{
        //    if (File.Exists(path))
        //    {
        //        string ingredientF = File.ReadAllText(path);
        //        return DataSerializer.Deserialize<Ingredient>(ingredientF);
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Метод записи в формате JSON и их сериализация
        ///// </summary>

        //public void Write(Ingredient ingredientF)
        //{
        //    File.WriteAllText(path, DataSerializer.Serialize(ingredientF));
        //}
    }
}
