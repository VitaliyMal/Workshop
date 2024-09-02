using System.ComponentModel.DataAnnotations;

namespace Workshop.Server.DTOs
{
    public class AddIngredientDTO(
        [Required][StringLength(255)] string Title,
        int Amount,
        int MinimalAmount,
        int Cost,
        [Range (1,5)] int IngredientType_id
        );
}