using System.ComponentModel.DataAnnotations;
using Workshop.Server.Entity;

namespace Workshop.Server.DTOs.OrderDTOs
{
    public record class OrderDTO
    (
        int Id,
        string Description,

        int Product_id,
        int Customer_id,
        int State_Type_id
    );
}
