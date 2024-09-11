using Workshop.Server.DTOs.IngredientDTOs;
using WorkshopWeb.Entity;

namespace Workshop.Server.Mapper
{
    public static class IngredientMapper
    {
        public static Ingredient ToEntity(this AddIngredientDTO addIngredient)
        {
            return new Ingredient()
            {
                Title = addIngredient.Title,
                Amount = addIngredient.Amount,
                MinimalAmount = addIngredient.MinimalAmount,
                Cost = addIngredient.Cost,
                IngredientType_id = addIngredient.IngredientType_id
            };
        }

        public static Ingredient ToEntity(this UpdateIngredientDTO UpIngredient, int id)
        {
            return new Ingredient()
            {
                Title = UpIngredient.Title,
                Amount = UpIngredient.Amount,
                MinimalAmount = UpIngredient.MinimalAmount,
                Cost = UpIngredient.Cost,
                IngredientType_id = UpIngredient.IngredientType_id
            };
        }

        public static IngredientDTO ToIngredientDTO(this Ingredient ingredient)
        {
            return new IngredientDTO(
                ingredient.Id,
                ingredient.Title,
                ingredient.Amount,
                ingredient.MinimalAmount,
                ingredient.Cost,
                ingredient.IngredientType_id
            );
        }

    }
}
