﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using Workshop.Core.Utility;
using Workshop.Server.DTOs.IngredientDTOs;
//using Workshop.Server.DTOs.CustomerDTOs;

namespace Workshop.Core.Data.Remote
{
    public class IngredientRemoteDataSource
    {
        public static readonly HttpClient client = new HttpClient();

        public IngredientRemoteDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5253/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<IngredientDTO> GetIngredient(int id)
        {
            IngredientDTO ingredient = null;

            HttpResponseMessage response = await client.GetAsync($"api/Ingredients/{id}");
            if (response.IsSuccessStatusCode)
            {
                ingredient = DataSerializer.Deserialize<IngredientDTO>(
                    await response.Content.ReadAsStringAsync());
            }
            return ingredient;
        }

        public async Task<List<IngredientDTO>> GetIngredients()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/Ingredients");
            response.EnsureSuccessStatusCode();

            List<IngredientDTO> IngredientsResponse = new List<IngredientDTO>();
            if (response.IsSuccessStatusCode)
            {
                IngredientsResponse = DataSerializer.Deserialize<List<IngredientDTO>>(
                    await response.Content.ReadAsStringAsync());
            }
            return IngredientsResponse;
        }

        public async Task PostIngredient(AddIngredientDTO ingredient)
        {

            HttpResponseMessage response = await client.PostAsync(
                "api/Ingredients", JsonContent.Create(ingredient));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Добавление ингредиента завершилось с ошибкой!");
            }
            return;
        }

        public async Task UpdateIngredient(UpdateIngredientDTO ingredient)
        {
            var json = JsonContent.Create(ingredient);

            HttpResponseMessage response = await client.PutAsync(
                $"api/Ingredients", json);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Изменение ингредиента завершилось с ошибкой!");
            }
            return;
        }

        public async Task DeleteIngredient(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Ingredients/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Удаление ингредиента завершилось с ошибкой!");
            }
            return;
        }
    }
}
