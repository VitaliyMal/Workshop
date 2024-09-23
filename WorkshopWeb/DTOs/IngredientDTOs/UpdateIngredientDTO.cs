using System.ComponentModel.DataAnnotations;

namespace Workshop.Server.DTOs.IngredientDTOs
{
    public record class UpdateIngredientDTO(
        [Required] int id,
        [Required][StringLength(255)] string Title,
        int Amount,
        int MinimalAmount,
        int Cost,
        [Range(1, 6)] int IngredientType_id
        );
}
