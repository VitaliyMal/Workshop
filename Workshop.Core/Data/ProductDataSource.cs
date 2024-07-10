using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.Entity;
using Workshop.Core.Utility;

namespace Workshop.Core.Data
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
                string productF = File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Product>>(productF);
            }
            return null;
        }

        /// <summary>
        /// Метод записи в формате JSON и их сериализация
        /// </summary>

        public void Write(List<Product> productF)
        {
            File.WriteAllText(path, DataSerializer.Serialize(productF));
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
