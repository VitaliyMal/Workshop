using System.ComponentModel.DataAnnotations;

namespace Workshop.Server.DTOs.RecipeDTOs
{
    public record class AddRecipeDTO
    (
        [Required] int Id_Ingredient,
        [Required] int Id_Product
    );
}
