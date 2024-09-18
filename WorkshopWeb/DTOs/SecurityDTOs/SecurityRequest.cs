using System.ComponentModel.DataAnnotations;

namespace Workshop.Server.DTOs.SecurityDTOs
{
    public record class SecurityRequest
    (
        [Required]/*[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина логина должна составлять от 3 до 50 символов!")]*/ string Login,

        [Required]/*[StringLength(50, MinimumLength = 5, ErrorMessage = "Длина пароля должна составлять от 5 до 50 символов!")]*/  string Password
    );
}
