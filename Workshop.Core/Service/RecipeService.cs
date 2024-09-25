using Workshop.Core.Data.Remote;
using Workshop.Server.DTOs.RecipeDTOs;

namespace Workshop.Core.Service
{
    public class RecipeService
    {
        private RecipeRemoteDataSource _dataSource;

        public RecipeService(RecipeRemoteDataSource dataSource)
        {
            _dataSource = dataSource;
        }


        public async Task<List<RecipeDTO>> GetAll()
        {
            return await _dataSource.GetRecipes();
        }

        public async Task<RecipeDTO?> Get(int id)
        {
            foreach (RecipeDTO recipe in await _dataSource.GetRecipes())
            {
                if (recipe.Id == id)
                {
                    return recipe;
                }
            }
            return null;
        }

        public async Task Create(RecipeDTO recipe)
        {
            try
            {
                await _dataSource.PostRecipe(new AddRecipeDTO(
                    recipe.Id_Ingredient,
                    recipe.Id_Product
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
                await _dataSource.DeleteRecipe(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(UpgradeRecipeDTO recipe)
        {
            try
            {
                await _dataSource.UpdateRecipe(new UpgradeRecipeDTO(
                    recipe.id,
                    recipe.Id_Ingredient,
                    recipe.Id_Product
                    ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
