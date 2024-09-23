using System.Net.Http.Headers;
using System.Net.Http.Json;
using Workshop.Core.Utility;
//using Workshop.Server.DTOs.CustomerDTOs;
using Workshop.Server.DTOs.Ingredient_TypeDTOs;

namespace Workshop.Core.Data.Remote
{
    public class Ingredient_TypeRemoteDataSource
    {
        public static readonly HttpClient client = new HttpClient();

        public Ingredient_TypeRemoteDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5253/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<Ingredient_TypeDTO> GetIngredient_Type(int id)
        {
            Ingredient_TypeDTO ingredient_Type = null;

            HttpResponseMessage response = await client.GetAsync($"api/IngredientType/{id}");
            if (response.IsSuccessStatusCode)
            {
                ingredient_Type = DataSerializer.Deserialize<Ingredient_TypeDTO>(
                    await response.Content.ReadAsStringAsync());
            }
            return ingredient_Type;
        }

        public async Task<List<Ingredient_TypeDTO>> GetIngredient_Types()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/IngredientType");
            response.EnsureSuccessStatusCode();

            List<Ingredient_TypeDTO> Ingredient_TypeResponse = new List<Ingredient_TypeDTO>();
            if (response.IsSuccessStatusCode)
            {
                Ingredient_TypeResponse = DataSerializer.Deserialize<List<Ingredient_TypeDTO>>(
                    await response.Content.ReadAsStringAsync());
            }
            return Ingredient_TypeResponse;
        }

        public async Task PostIngredient_Type(AddIngredient_TypeDTO ingredient_Type)
        {

            HttpResponseMessage response = await client.PostAsync(
                "api/IngredientType", JsonContent.Create(ingredient_Type));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Добавление типа ингредиента завершилось с ошибкой!");
            }
            return;
        }

        public async Task UpdateIngredientType(UpgradeIngredient_TypeDTO ingredient_Type)
        {
            var json = JsonContent.Create(ingredient_Type);

            HttpResponseMessage response = await client.PutAsync(
                $"api/IngredientType", json);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Изменение типа ингредиента завершилось с ошибкой!");
            }
            return;
        }

        public async Task DeleteIngredientType(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/IngredientType/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Удаление заказчика завершилось с ошибкой!");
            }
            return;
        }
    }
}
