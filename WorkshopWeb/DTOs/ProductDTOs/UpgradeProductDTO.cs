namespace Workshop.Server.DTOs.ProductDTOs
{
    public record class UpgradeProductDTO
    (
        string Name,
        string Description,
        int Price,
        int Production_time
    );
}
