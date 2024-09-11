using Workshop.Core.Data;
using Workshop.Core.Entity;

namespace Workshop.Core.Service
{
    public class OrderService
    {
        public OrderDataSource _dataSource;
        private List<Order> _orders = [];

        public OrderService(OrderDataSource dataSource)
        {
            _dataSource = dataSource;
            _orders = _dataSource.Get() ?? new List<Order>();
        }

        public List<Order> GetAll()
        {
            return _orders;
        }

        public Order Get(int id)
        {
            foreach (Order order in _orders)
            {
                if (order.OrderId == id)
                {
                    return order;
                }
            }
            return null;
        }
        public void Create(Order order)
        {
            _orders.Add(order);
            _dataSource.Write(_orders);

        }

        public void Delete(int id)
        {
            foreach (Order order in _orders)
            {
                if (order.OrderId == id)
                {
                    _orders.Remove(order);
                    break;
                }
            }

            _dataSource.Write(_orders);
        }

        public void Update(Order order)
        {
            for (int i = 0; i < _orders.Count; i++)
                if (order.OrderId == _orders[i].OrderId)
                    _orders[i] = order;
            _dataSource.Write(_orders);

        }


    }
}
