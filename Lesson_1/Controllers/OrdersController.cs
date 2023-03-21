using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Order>>> Get()
    {
        List<Order> orders = await _orderService.GetOrders();
        return orders == null ? NoContent() : Ok(orders);

    }

    // GET api/<CategoriesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> Get(int id)
    {
        Order order = await _orderService.GetOrderById(id);
        return order == null ? NoContent() : Ok(order);
    }

    // POST api/<CategoriesController>
    [HttpPost]
    public async Task<ActionResult<Order>> Post([FromBody] Order newOrder)
    {
        Order order = await _orderService.CreateOrder(newOrder);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }
    }
}
