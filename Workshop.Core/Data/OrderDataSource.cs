using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.Entity;
using Workshop.Core.Utility;

namespace Workshop.Core.Data
{
    public class OrderDataSource
    {
        private readonly string path = ".\\Order.json";

        /// <summary>
        /// Метод чтения в формате JSON и их десериализация
        /// </summary>

        public List<Order> Get()
        {
            if (File.Exists(path))
            {
                string orderF = File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Order>>(orderF);
            }
            return null;
        }

        /// <summary>
        /// Метод записи в формате JSON и их сериализация
        /// </summary>

        public void Write(List<Order> orderF)
        {
            File.WriteAllText(path, DataSerializer.Serialize(orderF));
        }


        /// <summary>
        /// Принимает не лист, а один экземпляр класса.
        /// </summary>
        /// <returns></returns>
        //public Order Get()
        //{
        //    if (File.Exists(path))
        //    {
        //        string orderF = File.ReadAllText(path);
        //        return DataSerializer.Deserialize<Order>(orderF);
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Метод записи в формате JSON и их сериализация
        ///// </summary>

        //public void Write(Order orderF)
        //{
        //    File.WriteAllText(path, DataSerializer.Serialize(orderF));
        //}
    }
}
