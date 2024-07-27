using CrudRestOrder.Dtos;
using CrudRestOrder.Mappers;
using CrudRestOrder.Repositories;
using CrudRestOrder.Response;
using System.Text.Json;

namespace CrudRestOrder.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly HttpClient _httpClient;

        public OrderService(IOrderRepository orderRepository, HttpClient httpClient)
        {
            _orderRepository = orderRepository;
            _httpClient = httpClient;
        }

        public async Task<Response<OrderDto>> AddOrderAsync(RqOrderDto orderDto)
        {
            var orderModel = OrderMapper.OrderDtoToModel(orderDto);
            await _orderRepository.AddAsync(orderModel);
            return new Response<OrderDto>("success", "Order created successfully", null);
        }

        public async Task<Response<OrderDto>> DeleteAsync(int id)
        {
            _orderRepository.DeleteAsync(id);
            return new Response<OrderDto>("success", "Order delete successfully", null);

        }

        public async Task<Response<IEnumerable<OrderWithProductDto>>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            if (orders.Count() == 0 && orders == null)
            {
                return new Response<IEnumerable<OrderWithProductDto>>("error", "not data found", null);
            }
            var orderWithProductsDto = new List<OrderWithProductDto>();
            foreach (var order in orders)
            {
                var productResponse = await _httpClient.GetAsync($"https://localhost:7015/api/products{order.ProductId}");
                if (productResponse.IsSuccessStatusCode)
                {
                    var productJson = await productResponse.Content.ReadAsStringAsync();
                    var product = JsonSerializer.Deserialize<ProductDto>(productJson);
                    orderWithProductsDto.Add(new OrderWithProductDto
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        ProductName = product.Name,
                        ProductPrice = product.Price,
                        Quantity = product.Quantity,


                    });
                }

            }
            return new Response<IEnumerable<OrderWithProductDto>>("success", "Orders got successfully", orderWithProductsDto);
        }

        public async Task<Response<OrderWithProductDto>> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            OrderWithProductDto orderWithProductDto = null;
            if (order == null)
            {
                return new Response<OrderWithProductDto>("error","data not found", null);
            }
            var productResponse = await _httpClient.GetAsync($"https://localhost:7015/api/products/{order.ProductId}");
            if (productResponse.IsSuccessStatusCode)
            {
                var productJson = await productResponse.Content.ReadAsStringAsync();
                var productResponseObj = JsonSerializer.Deserialize<ProductResponseDto>(productJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var product = productResponseObj.Data;
                orderWithProductDto = new OrderWithProductDto
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    Quantity = product.Quantity


                };
                return new Response<OrderWithProductDto>("success", "data found", orderWithProductDto);
            }
            return new Response<OrderWithProductDto>("error", "data product not found", orderWithProductDto);

        }

        public async Task<Response<OrderDto>> UpdateAsync(int id, RqOrderDto orderDto)
        {
            var orderFound = await _orderRepository.GetByIdAsync(id);
            if (orderFound == null) {
                return new Response<OrderDto>("error", "data product not found", null);
            }
            orderFound.ProductId = orderDto.ProductId;
            orderFound.Quantity = orderDto.Quantity;
            var updateOrder = await _orderRepository.UpdateAsync(orderFound);
            var updateOrderDto = OrderMapper.OrderModelToDto(updateOrder);
            return new Response<OrderDto>("success", "Order updated successfully", updateOrderDto);

        }
    }
}
