using System.ComponentModel.DataAnnotations;

namespace Workshop.Server.DTOs.Ingredient_TypeDTOs
{
    public record class AddIngredient_TypeDTO
    (
        [Required][StringLength(255)] string IngredientTypeTitle
    );
}
