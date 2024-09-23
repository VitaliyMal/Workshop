using System.ComponentModel.DataAnnotations;

namespace Workshop.Server.DTOs.OrderDTOs
{
    public record class UpgradeOrderDTO
    (
        [Required] int id,
        string Description,

        [Required][Range(1, double.MaxValue)] int Product_id,
        [Required][Range(1, double.MaxValue)] int Customer_id,
        [Required][Range(1, 5)] int State_Type_id
    );
}
