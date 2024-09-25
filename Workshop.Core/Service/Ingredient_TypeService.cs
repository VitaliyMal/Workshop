using Workshop.Core.Data.Remote;
using Workshop.Server.DTOs.Ingredient_TypeDTOs;

namespace Workshop.Core.Service
{
    public class Ingredient_TypeService
    {
        private Ingredient_TypeRemoteDataSource _dataSource;

        public Ingredient_TypeService(Ingredient_TypeRemoteDataSource dataSource)
        {
            _dataSource = dataSource;
        }


        public async Task<List<Ingredient_TypeDTO>> GetAll()
        {
            return await _dataSource.GetIngredient_Types();
        }

        public async Task<Ingredient_TypeDTO?> Get(int id)
        {
            foreach (Ingredient_TypeDTO ingredient_Type in await _dataSource.GetIngredient_Types())
            {
                if (ingredient_Type.Id == id)
                {
                    return ingredient_Type;
                }
            }
            return null;
        }

        public async Task Create(Ingredient_TypeDTO ingredient_Type)
        {
            try
            {
                await _dataSource.PostIngredient_Type(new AddIngredient_TypeDTO(
                    ingredient_Type.IngredientTypeTitle
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
                await _dataSource.DeleteIngredientType(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(UpgradeIngredient_TypeDTO ingredient_Type)
        {
            try
            {
                await _dataSource.UpdateIngredient_Type(new UpgradeIngredient_TypeDTO(
                    ingredient_Type.id,
                    ingredient_Type.IngredientTypeTitle
                    ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
