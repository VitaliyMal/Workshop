using System.ComponentModel.DataAnnotations;

namespace Workshop.Server.DTOs.ProductDTOs
{
    public record class AddProductDTO
    (        
        [Required] string Name,
        string Description,
        int Price,
        int Production_time
    );
}
