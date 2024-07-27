using CrudRest.Dtos;
using CrudRest.Response;

namespace CrudRest.Services
{
    public interface IProductService
    {
        Task<Response<IEnumerable<ProductDto>>> GetAllAsync();
        Task<Response<ProductDto>> GetByIdAsync(int id);
        Task<Response<ProductDto>> AddAsync(RqProductDto product);
        Task<Response<ProductDto>> UpdateAsync(int id, RqProductDto product);
        Task<Response<ProductDto>> DeleteAsync(int id);
    }
}
