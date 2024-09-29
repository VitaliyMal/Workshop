using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.Utility;
using Workshop.Server.DTOs.Ingredient_TypeDTOs;
using Workshop.Server.DTOs.State_TypeDTOs;

namespace Workshop.Core.Data.Remote
{
    public class State_TypeRemoteDataSource
    {
        public static readonly HttpClient client = new HttpClient();

        public State_TypeRemoteDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5253/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<State_TypeDTO> GetState_Type(int id)
        {
            State_TypeDTO state_Type = null;

            HttpResponseMessage response = await client.GetAsync($"api/State_Type/{id}");
            if (response.IsSuccessStatusCode)
            {
                state_Type = DataSerializer.Deserialize<State_TypeDTO>(
                    await response.Content.ReadAsStringAsync());
            }
            return state_Type;
        }

        public async Task<List<State_TypeDTO>> GetState_Types()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/State_Type");
            response.EnsureSuccessStatusCode();

            List<State_TypeDTO> State_TypeResponse = new List<State_TypeDTO>();
            if (response.IsSuccessStatusCode)
            {
                State_TypeResponse = DataSerializer.Deserialize<List<State_TypeDTO>>(
                    await response.Content.ReadAsStringAsync());
            }
            return State_TypeResponse;
        }

        public async Task PostState_Type(AddState_TypeDTO state_Type)
        {

            HttpResponseMessage response = await client.PostAsync(
                "api/State_Type", JsonContent.Create(state_Type));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Добавление типа состояния завершилось с ошибкой!");
            }
            return;
        }

        public async Task UpdateState_Type(UpgradeState_TypeDTO state_Type)
        {
            var json = JsonContent.Create(state_Type);

            HttpResponseMessage response = await client.PutAsync(
                $"api/State_Type", json);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Изменение типа состояния завершилось с ошибкой!");
            }
            return;
        }

        public async Task DeleteState_Type(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/State_Type/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Удаление типа состояния завершилось с ошибкой!");
            }
            return;
        }
    }
}

