using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.Entity;
using Workshop.Core.Utility;

namespace Workshop.Core.Data
{
    public class CustomerDataSource
    {
        private readonly string path = ".\\Customer.json";

        /// <summary>
        /// Метод чтения в формате JSON и их десериализация
        /// </summary>

        public List<Customer> Get()
        {
            if (File.Exists(path))
            {
                string customerF = File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Customer>>(customerF);
            }
            return null;
        }

        /// <summary>
        /// Метод записи в формате JSON и их сериализация
        /// </summary>

        public void Write(List<Customer> customerF)
        {
            File.WriteAllText(path, DataSerializer.Serialize(customerF));
        }



        /// <summary>
        /// Принимает не лист, а один экземпляр класса.
        /// </summary>
        /// <returns></returns>
        //public Customer Get()
        //{
        //    if (File.Exists(path))
        //    {
        //        string customerF = File.ReadAllText(path);
        //        return DataSerializer.Deserialize<Customer>(customerF);
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Метод записи в формате JSON и их сериализация
        ///// </summary>

        //public void Write(Customer customerF)
        //{
        //    File.WriteAllText(path, DataSerializer.Serialize(customerF));
        //}
    }
}
