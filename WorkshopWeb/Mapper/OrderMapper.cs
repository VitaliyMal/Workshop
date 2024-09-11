using Workshop.Server.DTOs.OrderDTOs;
using Workshop.Server.Entity;


namespace Workshop.Server.Mapper
{
    public static class OrderMapper
    {
        public static Order ToEntity(this AddOrderDTO addOrder)
        {
            return new Order()
            {
                Description = addOrder.Description,
                Product_id = addOrder.Product_id,
                Customer_id = addOrder.Customer_id,
                State_Type_id = addOrder.State_Type_id
            };
        }

        public static Order ToEntity(this UpgradeOrderDTO UpOrder, int id)
        {
            return new Order()
            {
                Description = UpOrder.Description,
                Product_id = UpOrder.Product_id,
                Customer_id = UpOrder.Customer_id,
                State_Type_id = UpOrder.State_Type_id
            };
        }

        public static OrderDTO ToOrderDTO(this Order order)
        {
            return new OrderDTO(
                order.Id,
                order.Description,
                order.Product_id,
                order.Customer_id,
                order.State_Type_id
            );
        }
    }
}


