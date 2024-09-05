namespace Workshop.Server.Entity
{
    public class Order // проверить правильность составления сущности
    {
        public int Id { get; set; }

        public int Product_id { get; set; }
        public string Product_name { get; set; }

        public int Customer_id { get; set; }
        public string Customer_name { get; set; }


    }
}
