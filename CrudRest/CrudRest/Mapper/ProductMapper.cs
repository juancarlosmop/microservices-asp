using CrudRest.Controllers;
using CrudRest.Dtos;
using CrudRest.Models;
namespace CrudRest.Mapper
{
    public class ProductMapper
    {
        public static List<ProductDto> ListProductModelToDto(IEnumerable<Product> products) {
            return products.Select(product=> new ProductDto {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity

            }).ToList();
        }

        public static ProductDto ProductModelToDto(Product product) {

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity

            };
        }

        public static Product ProductDtoToModel(RqProductDto product) {
            return new Product
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }
    }
}
