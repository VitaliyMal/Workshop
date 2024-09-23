using System.ComponentModel.DataAnnotations;

namespace Workshop.Server.DTOs.State_TypeDTOs
{
    public record class UpgradeState_TypeDTO
    (
        [Required] int id,
        [Required] string State_Type_Title ///enum???
    );
}
