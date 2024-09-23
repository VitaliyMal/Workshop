using System.Net.Http.Headers;
using System.Net.Http.Json;
using Workshop.Core.Utility;
using Workshop.Server.DTOs.RecipeDTOs;
//using Workshop.Server.DTOs.CustomerDTOs;

namespace Workshop.Core.Data.Remote
{
    public class RecipeRemoteDataSource
    {
        public static readonly HttpClient client = new HttpClient();

        public RecipeRemoteDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5253/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<RecipeDTO> GetRecipe(int id)
        {
            RecipeDTO recipe = null;

            HttpResponseMessage response = await client.GetAsync($"api/Recipes/{id}");
            if (response.IsSuccessStatusCode)
            {
                recipe = DataSerializer.Deserialize<RecipeDTO>(
                    await response.Content.ReadAsStringAsync());
            }
            return recipe;
        }

        public async Task<List<RecipeDTO>> GetRecipes()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/Recipes");
            response.EnsureSuccessStatusCode();

            List<RecipeDTO> RecipeResponse = new List<RecipeDTO>();
            if (response.IsSuccessStatusCode)
            {
                RecipeResponse = DataSerializer.Deserialize<List<RecipeDTO>>(
                    await response.Content.ReadAsStringAsync());
            }
            return RecipeResponse;
        }

        public async Task PostRecipe(AddRecipeDTO recipe)
        {
            HttpResponseMessage response = await client.PostAsync(
                "api/Recipes", JsonContent.Create(recipe));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Добавление рецепта завершилось с ошибкой!");
            }
            return;
        }

        public async Task UpdateRecipe(UpgradeRecipeDTO recipe)
        {
            var json = JsonContent.Create(recipe);

            HttpResponseMessage response = await client.PutAsync(
                $"api/Recipes", json);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Изменение рецепта завершилось с ошибкой!");
            }
            return;
        }

        public async Task DeleteRecipe(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Recipes/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Удаление рецепта завершилось с ошибкой!");
            }
            return;
        }
    }
}
