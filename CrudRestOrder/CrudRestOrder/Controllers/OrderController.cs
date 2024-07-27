using CrudRestOrder.Dtos;
using CrudRestOrder.Response;
using CrudRestOrder.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudRestOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService iorderService)
        {
            _orderService = iorderService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<OrderWithProductDto>>>> GetAllOrders()
        {
            return await _orderService.GetAllOrdersAsync();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<OrderWithProductDto>>> GetAllProducts(int id)
        {
            return await _orderService.GetOrderByIdAsync(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Response<OrderDto>>> createOrder(RqOrderDto order)
        {
            return await _orderService.AddOrderAsync(order);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<OrderDto>>> updateOrder(int id, RqOrderDto order)
        {
            return await _orderService.UpdateAsync(id, order);
        }

        [HttpDelete]
        public async Task<ActionResult<Response<OrderDto>>> deleteOrder(int id)
        { 
            return await _orderService.DeleteAsync(id);
        }

    }
}
