using WorkshopWeb.Entity;

namespace Workshop.Server.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        public int Product_id { get; set; }
        public Product? Product { get; set; }

        public int Customer_id { get; set; }
        public Customer? Customer { get; set; }

        public int State_Type_id { get; set; }
        public State_Type? State { get; set; }


    }
}
