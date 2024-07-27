using CrudRest.Models;

namespace CrudRest.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product>  GetByIdAsync(int id);
        Task<Product> AddAsyncs(Product product);
        Task<Product> UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
