using Workshop.Server.DTOs.RecipeDTOs;
using Workshop.Server.Entity;

namespace Workshop.Server.Mapper
{
    public static class RecipeMapper
    {
        public static Recipe ToEntity(this AddRecipeDTO addRecipe)
        {
            return new Recipe()
            {
                Id_Ingredient = addRecipe.Id_Ingredient,
                Id_Product = addRecipe.Id_Product
            };
        }

        public static Recipe ToEntity(this UpgradeRecipeDTO upRecipe, int id)
        {
            return new Recipe()
            {
                Id = id,
                Id_Ingredient = upRecipe.Id_Ingredient,
                Id_Product = upRecipe.Id_Product
            };
        }

        public static RecipeDTO ToRecipeDTO(this Recipe recipe)
        {
            return new RecipeDTO(
                recipe.Id,
                recipe.Id_Ingredient,
                recipe.Id_Product
            );
        }
    }
}
