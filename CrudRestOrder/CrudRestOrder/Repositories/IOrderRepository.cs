using CrudRestOrder.Dtos;
using CrudRestOrder.Models;

namespace CrudRestOrder.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task<Order> UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }
}
