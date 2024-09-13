//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;
//using Workshop.Core.Utility;
////using Workshop.Server.DTOs.CustomerDTOs;
//using Workshop.Server.DTOs.Ingredient_TypeDTOs;

//namespace Workshop.Core.Data
//{
//    public class Ingredient_TypeRemoteDataSource
//    {
//        public static readonly HttpClient client = new HttpClient();

//        public Ingredient_TypeRemoteDataSource()
//        {
//            client.BaseAddress = new Uri("http://localhost:5253/");
//            client.DefaultRequestHeaders.Accept.Clear();
//            client.DefaultRequestHeaders.Accept.Add(
//                new MediaTypeWithQualityHeaderValue("application/json"));
//        }


//        public async Task<Ingredient_TypeDTO> GetIngredient_Type(int id)
//        {
//            Ingredient_TypeDTO ingredient_Type = null;

//            HttpResponseMessage response = await client.GetAsync($"api/Customers/{id}");
//            if (response.IsSuccessStatusCode)
//            {
//                ingredient_Type = DataSerializer.Deserialize<Ingredient_TypeDTO>(
//                    await response.Content.ReadAsStringAsync());
//            }
//            return ingredient_Type;
//        }

//        public async Task<List<Ingredient_TypeDTO>> GetCustomers()
//        {

//            HttpResponseMessage response = await client.GetAsync(
//                "api/Customers");
//            response.EnsureSuccessStatusCode();

//            List<Ingredient_TypeDTO> CustomerResponse = new List<Ingredient_TypeDTO>();
//            if (response.IsSuccessStatusCode)
//            {
//                CustomerResponse = DataSerializer.Deserialize<List<Ingredient_TypeDTO>>(
//                    await response.Content.ReadAsStringAsync());
//            }
//            return CustomerResponse;
//        }

//        public async Task PostCustomer(AddCustomerDTO customer)
//        {

//            HttpResponseMessage response = await client.PostAsync(
//                "api/Customers", new StringContent(DataSerializer.Serialize(customer)));
//            response.EnsureSuccessStatusCode();

//            if (!response.IsSuccessStatusCode)
//            {
//                throw new Exception();
//            }
//            return;
//        }

//        public async Task UpdateCustomer(UpgradeCustomerDTO customer)
//        {

//            HttpResponseMessage response = await client.PutAsync(
//                "api/Customers", new StringContent(DataSerializer.Serialize(customer)));
//            response.EnsureSuccessStatusCode();

//            if (!response.IsSuccessStatusCode)
//            {
//                throw new Exception();
//            }
//            return;
//        }

//        public async Task DeleteCustomer(int id)
//        {
//            HttpResponseMessage response = await client.DeleteAsync($"api/Customers/{id}");
//            if (!response.IsSuccessStatusCode)
//            {
//                throw new Exception();
//            }
//            return;
//        }
//    }
//}
