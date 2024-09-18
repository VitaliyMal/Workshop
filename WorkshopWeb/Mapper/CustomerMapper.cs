using Workshop.Server.DTOs.CustomerDTOs;
using Workshop.Server.Entity;

namespace Workshop.Server.Mapper
{
    public static class CustomerMapper
    {
        public static Customer ToEntity(this AddCustomerDTO addCustomer)
        {
            return new Customer()
            {
                Name = addCustomer.Name,
                LastName = addCustomer.LastName,
                Adress = addCustomer.Adress,
                Login = addCustomer.Login,
                Password = addCustomer.Password
            };
        }

        public static Customer ToEntity(this UpgradeCustomerDTO UpCustomer, int id)
        {
            return new Customer()
            {
                Id = id,
                Name = UpCustomer.Name,
                LastName = UpCustomer.LastName,
                Adress = UpCustomer.Adress,
                Login = UpCustomer.Login,
                Password = UpCustomer.Password
            };
        }

        public static CustomerDTO ToCustomerDTO(this Customer customer)
        {
            return new CustomerDTO(
                customer.Id,
                customer.Name ?? "",
                customer.LastName ?? "",
                customer.Adress ?? "",
                customer.Login,
                customer.Password
            );
        }

    }
}
