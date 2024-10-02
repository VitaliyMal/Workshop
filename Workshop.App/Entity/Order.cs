using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Server.DTOs.CustomerDTOs;
using Workshop.Server.DTOs.OrderDTOs;
using Workshop.Server.DTOs.ProductDTOs;
using Workshop.Server.DTOs.State_TypeDTOs;

namespace Workshop.App.Entity
{
    public class Order
    {
        public Order(OrderDTO x,ProductDTO productDTO,CustomerDTO customerDTO,State_TypeDTO state_TypeDTO) 
        {
            orderDTO = x;
            productDTO = productDTO;
            customerDTO = customerDTO;
            state_TypeDTO = state_TypeDTO
        }

        public OrderDTO orderDTO {  get; set; }
        public ProductDTO productDTO { get; set; }
        public CustomerDTO customerDTO { get; set; }
        public State_TypeDTO state_TypeDTO { get; set; }

    }
}
