namespace Workshop.Server.DTOs.SecurityDTOs
{
    public record class SecurityResponse //Можно добавить доп. информацию о пользователе - ФИО, дата рождения и т.д.
    (
        int Id
    );
}
