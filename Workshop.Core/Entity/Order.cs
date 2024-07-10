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
    public class Order(int orderId, int customerId = 0, State state = 0, List<Product> products = null)
    {

        public int OrderId { get; set; } = orderId;

        public int CustomerId { get; set; } = customerId;

        public State State { get; set; } = state;

        public List<Product> Products { get; set; } = products;



    }
}
