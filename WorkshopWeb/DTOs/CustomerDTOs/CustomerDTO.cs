namespace Workshop.Server.DTOs.CustomerDTOs
{
    public record class CustomerDTO
    (
        int Id,
        string Name,
        string LastName,
        string Adress,
        string Login,
        string Password
    );
}
