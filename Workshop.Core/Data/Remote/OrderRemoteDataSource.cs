using System.Net.Http.Headers;
using System.Net.Http.Json;
using Workshop.Core.Utility;
//using Workshop.Server.DTOs.CustomerDTOs;
using Workshop.Server.DTOs.OrderDTOs;

namespace Workshop.Core.Data.Remote
{
    public class OrderRemoteDataSource
    {
        public static readonly HttpClient client = new HttpClient();

        public OrderRemoteDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5253/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<OrderDTO> GetOrder(int id)
        {
            OrderDTO order = null;

            HttpResponseMessage response = await client.GetAsync($"api/Orders/{id}");
            if (response.IsSuccessStatusCode)
            {
                order = DataSerializer.Deserialize<OrderDTO>(
                    await response.Content.ReadAsStringAsync());
            }
            return order;
        }

        public async Task<List<OrderDTO>> GetOrders()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/Orders");
            response.EnsureSuccessStatusCode();

            List<OrderDTO> OrderResponse = new List<OrderDTO>();
            if (response.IsSuccessStatusCode)
            {
                OrderResponse = DataSerializer.Deserialize<List<OrderDTO>>(
                    await response.Content.ReadAsStringAsync());
            }
            return OrderResponse;
        }

        public async Task PostOrder(AddOrderDTO order)
        {

            HttpResponseMessage response = await client.PostAsync(
                "api/Orders", JsonContent.Create(order));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Добавление заказа завершилось с ошибкой!");
            }
            return;
        }

        public async Task UpdateOrder(UpgradeOrderDTO order)
        {
            var json = JsonContent.Create(order);

            HttpResponseMessage response = await client.PutAsync(
                $"api/Orders", json);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Изменение заказа завершилось с ошибкой!");
            }
            return;
        }

        public async Task DeleteOrder(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Orders/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Удаление заказа завершилось с ошибкой!");
            }
            return;
        }
    }
}
