using Workshop.Core.Entity;
using Workshop.Core.Utility;

namespace Workshop.Core.Data.Direct
{
    public class ProductDataSource
    {
        private readonly string path = ".\\Product.json";

        /// <summary>
        /// Метод чтения в формате JSON и их десериализация
        /// </summary>

        public List<Product> Get()
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string data = reader.ReadToEnd();
                    var tmp = DataSerializer.Deserialize<List<Product>>(data) ?? [];
                    Product._idCounter = tmp.Count > 0 ? tmp.Select(x => x.Id).Max() + 1 : 0;
                    return tmp;
                }

            }
            return [];
        }

        /// <summary>
        /// Метод записи в формате JSON и их сериализация
        /// </summary>

        public void Write(List<Product> data)
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
        //public Product Get()
        //{
        //    if (File.Exists(path))
        //    {
        //        string productF = File.ReadAllText(path);
        //        return DataSerializer.Deserialize<Product>(productF);
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Метод записи в формате JSON и их сериализация
        ///// </summary>

        //public void Write(Product productF)
        //{
        //    File.WriteAllText(path, DataSerializer.Serialize(productF));
        //}
    }
}
