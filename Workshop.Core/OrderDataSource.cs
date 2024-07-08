using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Core
{
    public class OrderDataSource
    {
        private readonly string path = ".\\data.json";

        /// <summary>
        /// Метод чтения в формате JSON и их десериализация
        /// </summary>

        public List<Order> Get()
        {
            if (File.Exists(path))
            {
                string data=File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Order>>(data);
            }
            return null;
        }        
        
        /// <summary>
        /// Метод записи в формате JSON и их десериализация
        /// </summary>

        public void Write(List<Order> data)
        {
            File.WriteAllText(path,DataSerializer.Serialize(data));
        }
    }
}
