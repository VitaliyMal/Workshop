using Workshop.Server.DTOs.Ingredient_TypeDTOs;
using WorkshopWeb.Entity;


namespace Workshop.Server.Mapper
{
    public static class Ingredient_TypeMapper
    {
        public static Ingredient_Type ToEntity(this AddIngredient_TypeDTO addIngredient_Type)
        {
            return new Ingredient_Type()
            {
                IngredientTypeTitle = addIngredient_Type.IngredientTypeTitle
            };
        }

        public static Ingredient_Type ToEntity(this UpgradeIngredient_TypeDTO UpIngredient_Type, int id)
        {
            return new Ingredient_Type()
            {
                IngredientTypeTitle = UpIngredient_Type.IngredientTypeTitle
            };
        }

        public static Ingredient_TypeDTO ToIngredient_TypeDTO(this Ingredient_Type ingredient_Type)
        {
            return new Ingredient_TypeDTO(
                ingredient_Type.Id,
                ingredient_Type.IngredientTypeTitle
            );
        }
    }
}