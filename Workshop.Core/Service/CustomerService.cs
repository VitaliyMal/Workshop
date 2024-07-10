using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.Data;
using Workshop.Core.Entity;

namespace Workshop.Core.Service
{
    public class CustomerService
    {
        public CustomerDataSource _dataSource;
        private List<Customer>_customers=[];

        public CustomerService(CustomerDataSource dataSource)
        {
            _dataSource = dataSource;
            _customers = _dataSource.Get() ?? new List<Customer>();
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }

        public Customer Get(int id)
        {
            foreach (Customer customer  in _customers)
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
