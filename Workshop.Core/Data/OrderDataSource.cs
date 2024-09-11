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
                using (StreamReader reader = new StreamReader(path))
                {
                    string data = reader.ReadToEnd();
                    var tmp = DataSerializer.Deserialize<List<Order>>(data) ?? [];
                    Order._idCounter = tmp.Count > 0 ? tmp.Select(x => x.OrderId).Max() + 1 : 0;
                    return tmp;
                }

            }
            return [];
        }

        /// <summary>
        /// Метод записи в формате JSON и их сериализация
        /// </summary>

        public void Write(List<Order> data)
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
