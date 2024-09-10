using System.ComponentModel.DataAnnotations;

namespace Workshop.Server.DTOs.State_TypeDTOs
{
    public record class AddState_TypeDTO
    (
        [Required] string State_Type_Title ///enum???
    );
}
