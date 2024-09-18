namespace Workshop.Server.DTOs.IngredientDTOs
{
    public record class IngredientDTO(
        int Id,
        string Title,
        int Amount,
        int MinimalAmount,
        int Cost,
        int IngredientType_id
        );

}
