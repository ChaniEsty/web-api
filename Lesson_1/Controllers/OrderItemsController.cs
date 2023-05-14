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
public class OrderItemsController : ControllerBase
{
        IOrderItemService _orderItemService;
        IMapper _mapper;
        public OrderItemsController(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItemDto>>> Get()
        {
            List<OrderItem> orderItems = await _orderItemService.GetOrderItems();
            List<OrderItemDto> orderItemDtos = _mapper.Map<List<OrderItem>, List<OrderItemDto>>(orderItems);
            return orderItems == null ? NoContent() : Ok(orderItemDtos);

        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> Get(int orderId)
        {
            OrderItem orderItem = await _orderItemService.GetOrderItemByOrderId(orderId);
            OrderItemDto orderItemDto = _mapper.Map<OrderItem, OrderItemDto>(orderItem);
            return orderItem == null ? NoContent() : Ok(orderItemDto);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<OrderItemDto>> Post([FromBody] OrderItemDto newOrderItemDto)
        {
            OrderItem newOrderItem = _mapper.Map<OrderItemDto, OrderItem>(newOrderItemDto);
            OrderItem orderItem = await _orderItemService.CreateOrderItem(newOrderItem);
            OrderItemDto orderItemDto = _mapper.Map<OrderItem, OrderItemDto>(orderItem);
            return CreatedAtAction(nameof(Get), new { id = orderItemDto.Id }, orderItemDto);
        }
    }
}
