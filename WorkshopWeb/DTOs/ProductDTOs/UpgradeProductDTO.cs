using System.ComponentModel.DataAnnotations;
namespace Workshop.Server.DTOs.ProductDTOs
{
    public record class UpgradeProductDTO
    (
        [Required] int id,
        string Name,
        string Description,
        int Price,
        int Production_time
    );
}
