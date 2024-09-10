namespace Workshop.Server.DTOs.ProductDTOs
{
    public record class ProductDTO
    (
        int Id,
        string Name,
        string Description,
        int Price,
        int Production_time
    );
}
