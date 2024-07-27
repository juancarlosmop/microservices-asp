using CrudRest.Dtos;
using CrudRest.Mapper;
using CrudRest.Repositories;
using CrudRest.Response;

namespace CrudRest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) { 
            _productRepository = productRepository;
        }
        public async Task<Response<ProductDto>> AddAsync(RqProductDto product)
        {
           var productEntity = ProductMapper.ProductDtoToModel(product);
           var createdProductEntity= await _productRepository.AddAsyncs(productEntity);
           var createdProductDto = ProductMapper.ProductModelToDto(createdProductEntity);
           return new Response<ProductDto>("Successfully","Product Created", createdProductDto);
        }

        public async Task<Response<ProductDto>> DeleteAsync(int id)
        {
            _productRepository.DeleteAsync(id);
            return new Response<ProductDto>("Successfully", "Product Deleted", null);

        }

        public async Task<Response<IEnumerable<ProductDto>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            if (products.Count() == 0 && products == null) {
                return new Response<IEnumerable<ProductDto>>("Not data Found", "Products doesn´t exist", null);
            }
            var productsDto = ProductMapper.ListProductModelToDto(products);
            return new Response<IEnumerable<ProductDto>>("Found data", "Products", productsDto);
        }

        public async Task<Response<ProductDto>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) {
                return new Response<ProductDto>("Not data Found", "Products doesn´t exist", null);
            }
            var productDto = ProductMapper.ProductModelToDto(product);
            return new Response<ProductDto>("Product was found", "Products Exist", productDto);

        }

        public async Task<Response<ProductDto>> UpdateAsync(int id, RqProductDto product)
        {
            var productFound = await _productRepository.GetByIdAsync(id);
            if (productFound == null)
            {
                return new Response<ProductDto>("Not Found", "Product not found", null);
            }
            productFound.Name = product.Name;
            productFound.Price = product.Price;
            productFound.Quantity = product.Quantity;
            var updatedProduct = await _productRepository.UpdateAsync(productFound);
            var updatedProductDto = ProductMapper.ProductModelToDto(updatedProduct);
            return new Response<ProductDto>("Product updated", "Product updated successfully", updatedProductDto);
        }
    }
}
