using System.ComponentModel.DataAnnotations;

namespace Workshop.Server.DTOs.RecipeDTOs
{
    public record class UpgradeRecipeDTO
    (
        [Required] int id,
        int Id_Ingredient,
        int Id_Product
    );
}
