using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class OrderItemsController : ControllerBase
{
        IOrderItemService _orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItem>>> Get()
        {
            List<OrderItem> orderItems = await _orderItemService.GetOrderItems();
            return orderItems == null ? NoContent() : Ok(orderItems);

        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> Get(int orderId)
        {
            OrderItem orderItem = await _orderItemService.GetOrderItemByOrderId(orderId);
            return orderItem == null ? NoContent() : Ok(orderItem);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<OrderItem>> Post([FromBody] OrderItem newOrderItem)
        {
            OrderItem orderItem = await _orderItemService.CreateOrderItem(newOrderItem);
            return CreatedAtAction(nameof(Get), new { id = orderItem.Id }, orderItem);
        }
    }
}
