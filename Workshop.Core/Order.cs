namespace Workshop.Core
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
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public State State{ get; set; }

        public List<Product> Products { get; set; }



    }
}
