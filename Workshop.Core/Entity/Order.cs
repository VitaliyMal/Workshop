using Newtonsoft.Json;

namespace Workshop.Core.Entity
{
    public enum State
    {
        ToDo,
        InProgress,
        Ready,
        Canceled
    }

    /// <summary>
    /// Заказ
    /// </summary>
    public class Order(int customerId = 0, State state = 0, List<Product> products = null)
    {
        public static int _idCounter = 0;

        [JsonProperty("OrderId")]
        public int OrderId { get; set; } = _idCounter;

        public int CustomerId { get; set; } = customerId;

        public State State { get; set; } = state;

        public List<Product> Products { get; set; } = products;

        public override string ToString()
        {
            return string.Join(",", Convert.ToString(OrderId), Convert.ToString(customerId), Convert.ToString(State), Products);
        }


    }
}
