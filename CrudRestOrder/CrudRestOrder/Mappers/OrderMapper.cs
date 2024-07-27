using CrudRestOrder.Dtos;
using CrudRestOrder.Models;

namespace CrudRestOrder.Mappers
{
    public class OrderMapper
    {
        public static Order OrderDtoToModel(RqOrderDto order) {

            return new Order {
                ProductId = order.ProductId,
                Quantity = order.Quantity,
            };
        }
        public static OrderDto OrderModelToDto(Order order) {
            return new OrderDto
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity
            };
        }
    }
}
