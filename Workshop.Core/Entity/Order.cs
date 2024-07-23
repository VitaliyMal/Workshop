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
    public class Order
    {
        public Order(int customerId=0,  State state = State.Canceled , string description="", List<Product> products=null)
        {
            OrderId=_idCounter++;
            CustomerId = customerId;
            State = state;            
            Description = description;
            Products = products;
        }

        public Order()
        {
            OrderId = _idCounter++;
            CustomerId = 0;
            State = State.Canceled;            
            Description = "no_description";
            Products = null;
        }
        public static int _idCounter = 0;

        [JsonProperty("OrderId")]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public State State { get; set; }

        public string Description { get; set; }
        public List<Product> Products { get; set; }

   

        public override string ToString()
        {
            return string.Join(",", Convert.ToString(OrderId), Convert.ToString(CustomerId), Convert.ToString(State), Products, Description);
        }


    }
}
