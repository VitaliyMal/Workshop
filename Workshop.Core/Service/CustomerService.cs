using Workshop.Core.Data.Remote;
using Workshop.Core.Entity;
using Workshop.Server.DTOs.CustomerDTOs;


namespace Workshop.Core.Service
{
    public class CustomerService
    {
        private CustomerRemoteDataSource _dataSource;        

        public CustomerService(CustomerRemoteDataSource dataSource)
        {
            _dataSource = dataSource;
        }


        public async Task <List<CustomerDTO>> GetAll()
        {
            return await _dataSource.GetCustomers();
        }

        public async Task <CustomerDTO?> Get(int id)
        {
            foreach (CustomerDTO customer in await _dataSource.GetCustomers())
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public async Task Create(CustomerDTO customer)
        {
            try
            {
                await _dataSource.PostCustomer(new AddCustomerDTO(
                    customer.Name,
                    customer.LastName,
                    customer.Adress,
                    customer.Login,
                    customer.Password
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
                await _dataSource.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(UpgradeCustomerDTO customer)
        {
            try
            {
                await _dataSource.UpdateCustomer(new UpgradeCustomerDTO(
                    customer.id,
                    customer.Name,
                    customer.LastName,
                    customer.Adress,
                    customer.Login,
                    customer.Password
                    ));
            }
            catch (Exception ex) { 
                throw ex;
            }
        }
    }
}
