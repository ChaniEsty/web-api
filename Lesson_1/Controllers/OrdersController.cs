using AutoMapper;
using DTO;
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
    IMapper _mapper; 
    public OrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> Get()
    {
        List<Order> orders = await _orderService.GetOrders();
        List<OrderDto> ordersDto = _mapper.Map<List<Order>, List<OrderDto>>(orders);
        return orders == null ? NoContent() : Ok(ordersDto);

    }

    // GET api/<CategoriesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> Get(int id)
    {
        Order order = await _orderService.GetOrderById(id);
        OrderDto orderDto = _mapper.Map<Order, OrderDto>(order);
        return order == null ? NoContent() : Ok(orderDto);
    }
    // POST api/<CategoriesController>
    [HttpPost]
    public async Task<ActionResult<OrderDto>> Post([FromBody] OrderDto newOrderDto)
    {
        Order newOrder = _mapper.Map<OrderDto, Order>(newOrderDto);
        Order order = await _orderService.CreateOrder(newOrder);
        OrderDto orderDto = _mapper.Map<Order, OrderDto>(order);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, orderDto);
    }
    }
}
