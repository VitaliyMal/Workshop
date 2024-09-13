using System.Net.Http.Headers;
using Workshop.Core.Utility;
using Workshop.Server.DTOs.CustomerDTOs;


namespace Workshop.Core.Data
{
    public class CustomerRemoteDataSource
    {
        public static readonly HttpClient client = new HttpClient();

        public CustomerRemoteDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5253/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<CustomerDTO> GetCustomer(int id)
        {
            CustomerDTO customer = null;

            HttpResponseMessage response = await client.GetAsync($"api/Customers/{id}");
            if (response.IsSuccessStatusCode)
            {
                customer = DataSerializer.Deserialize<CustomerDTO>(
                    await response.Content.ReadAsStringAsync());
            }
            return customer;
        }

        public async Task<List<CustomerDTO>> GetCustomers()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/Customers");
            response.EnsureSuccessStatusCode();

            List<CustomerDTO> CustomerResponse = new List<CustomerDTO>();
            if (response.IsSuccessStatusCode)
            {
                CustomerResponse = DataSerializer.Deserialize<List<CustomerDTO>>(
                    await response.Content.ReadAsStringAsync());
            }
            return CustomerResponse;
        }

        public async Task PostCustomer(AddCustomerDTO customer)
        {

            HttpResponseMessage response = await client.PostAsync(
                "api/Customers", new StringContent(DataSerializer.Serialize(customer)));
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            return;
        }

        public async Task UpdateCustomer(UpgradeCustomerDTO customer)
        {

            HttpResponseMessage response = await client.PutAsync(
                "api/Customers", new StringContent(DataSerializer.Serialize(customer)));
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            return;
        }

        public async Task DeleteCustomer(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Customers/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            return;
        }
    }
}
