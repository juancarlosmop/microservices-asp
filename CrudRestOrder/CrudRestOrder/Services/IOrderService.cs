using CrudRestOrder.Dtos;
using CrudRestOrder.Response;

namespace CrudRestOrder.Services
{
    public interface IOrderService
    {
        Task<Response<IEnumerable<OrderWithProductDto>>> GetAllOrdersAsync();
        Task<Response<OrderDto>> AddOrderAsync(RqOrderDto orderDto);
        Task<Response<OrderWithProductDto>> GetOrderByIdAsync(int id);
        Task<Response<OrderDto>> UpdateAsync(int id,RqOrderDto orderDto);
        Task<Response<OrderDto>> DeleteAsync(int id);
    }
}
