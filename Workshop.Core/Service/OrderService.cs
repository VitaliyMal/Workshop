//using Workshop.Core.Data.Direct;
using Workshop.Core.Entity;
using Workshop.Core.Data.Remote;
using Workshop.Server.DTOs.OrderDTOs;

namespace Workshop.Core.Service
{
    public class OrderService
    {
        private OrderRemoteDataSource _dataSource;
        
        public OrderService(OrderRemoteDataSource dataSource)
        {
            _dataSource = dataSource;            
        }

        public async Task <List<OrderDTO>> GetAll()
        {
            return await _dataSource.GetOrders();
        }

        public async Task <OrderDTO?> Get(int id)
        {
            foreach (OrderDTO order in await _dataSource.GetOrders())
            {
                if (order.OrderId == id)
                {
                    return order;
                }
            }
            return null;
        }
        public async Task Create(OrderDTO order)
        {
            try
            {
                await _dataSource.PostOrder(new AddOrderDTO(
                    order.Description,
                    order.Product_id,
                    order.Customer_id,
                    order.State_Type_id
                    ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _dataSource.DeleteOrder(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(UpgradeOrderDTO order)
        {
            try
            {
                await _dataSource.UpdateOrder(new UpgradeOrderDTO(
                    order.id,
                    order.Description,
                    order.Product_id,
                    order.Customer_id,
                    order.State_Type_id
                    ));
            }
            catch (Exception ex) { 
                throw ex;
            }
        }


    }
}
