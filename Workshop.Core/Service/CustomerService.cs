//using Workshop.Core.Data.Direct;
using Workshop.Core.Data.Remote;
using Workshop.Core.Entity;


namespace Workshop.Core.Service
{
    public class CustomerService
    {
        public CustomerDataSource _dataSource;
        private List<Customer> _customers = new List<Customer>();

        public CustomerService(CustomerRemoteDataSource dataSource)
        {
            _dataSource = dataSource;            
        }

 
        public async Task GetAll()
        {
            await _dataSource.GetCustomers().Select(x => new Customer(x.Id, x.Title)).ToList();
        }

        public Customer Get(int id)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }
        public void Create(Customer customer)
        {
            _customers.Add(customer);
            _dataSource.Write(_customers);

        }

        public void Delete(int id)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.Id == id)
                {
                    _customers.Remove(customer);
                    break;
                }
            }

            _dataSource.Write(_customers);
        }

        public void Update(Customer customer)
        {
            for (int i = 0; i < _customers.Count; i++)
                if (customer.Id == _customers[i].Id)
                    _customers[i] = customer;
            _dataSource.Write(_customers);

        }


    }

}
