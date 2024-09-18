using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.Utility;
using Workshop.Server.DTOs.ProductDTOs;
//using Workshop.Server.DTOs.CustomerDTOs;

namespace Workshop.Core.Data.Remote
{
    public class ProductRemoteDataSource
    {
        public static readonly HttpClient client = new HttpClient();

        public ProductRemoteDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5253/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<ProductDTO> GetProduct(int id)
        {
            ProductDTO product = null;

            HttpResponseMessage response = await client.GetAsync($"api/Products/{id}");
            if (response.IsSuccessStatusCode)
            {
                product = DataSerializer.Deserialize<ProductDTO>(
                    await response.Content.ReadAsStringAsync());
            }
            return product;
        }

        public async Task<List<ProductDTO>> GetProduct()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/Products");
            response.EnsureSuccessStatusCode();

            List<ProductDTO> ProductResponse = new List<ProductDTO>();
            if (response.IsSuccessStatusCode)
            {
                ProductResponse = DataSerializer.Deserialize<List<ProductDTO>>(
                    await response.Content.ReadAsStringAsync());
            }
            return ProductResponse;
        }

        public async Task PostProduct(AddProductDTO product)
        {

            HttpResponseMessage response = await client.PostAsync(
                "api/Products", new StringContent(DataSerializer.Serialize(product)));
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            return;
        }

        public async Task UpdateProduct(UpgradeProductDTO product)
        {

            HttpResponseMessage response = await client.PutAsync(
                "api/Products", new StringContent(DataSerializer.Serialize(product)));
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            return;
        }

        public async Task DeleteProduct(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Products/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            return;
        }
    }
}
