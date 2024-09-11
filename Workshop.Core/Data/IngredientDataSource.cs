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
                using (StreamReader reader = new StreamReader(path))
                {
                    string data = reader.ReadToEnd();
                    var tmp = DataSerializer.Deserialize<List<Ingredient>>(data) ?? [];
                    Ingredient._idCounter = tmp.Count > 0 ? tmp.Select(x => x.Id).Max() + 1 : 0;
                    return tmp;
                }

            }
            return [];
        }

        /// <summary>
        /// Метод записи в формате JSON и их сериализация
        /// </summary>

        public void Write(List<Ingredient> data)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(DataSerializer.Serialize(data));
            }
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
