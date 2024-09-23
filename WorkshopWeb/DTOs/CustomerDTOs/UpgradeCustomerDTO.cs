using System.ComponentModel.DataAnnotations;

namespace Workshop.Server.DTOs.CustomerDTOs
{
    public record class UpgradeCustomerDTO
    (
        [Required] int id,
        string Name,
        string LastName,
        string Adress,
        string Login,
        string Password
    );
}
