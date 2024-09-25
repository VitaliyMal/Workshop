//using Workshop.Core.Data.Direct;
using Workshop.Core.Data.Remote;
using Workshop.Server.DTOs.IngredientDTOs;

namespace Workshop.Core.Service
{
    public class IngredientService
    {
        private IngredientRemoteDataSource _dataSource;

        public IngredientService(IngredientRemoteDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<List<IngredientDTO>> GetAll()
        {
            return await _dataSource.GetIngredients();
        }

        public async Task<IngredientDTO?> Get(int id)
        {
            foreach (IngredientDTO ingredient in await _dataSource.GetIngredients())
            {
                if (ingredient.Id == id)
                {
                    return ingredient;
                }
            }
            return null;
        }
        public async Task Create(IngredientDTO ingredient)
        {
            try
            {
                await _dataSource.PostIngredient(new AddIngredientDTO(
                    ingredient.Title,
                    ingredient.Amount,
                    ingredient.MinimalAmount,
                    ingredient.Cost,
                    ingredient.IngredientType_id
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
                await _dataSource.DeleteIngredient(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(UpdateIngredientDTO ingredient)
        {
            try
            {
                await _dataSource.UpdateIngredient(new UpdateIngredientDTO(
                    ingredient.id,
                    ingredient.Title,
                    ingredient.Amount,
                    ingredient.MinimalAmount,
                    ingredient.Cost,
                    ingredient.IngredientType_id
                    ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
