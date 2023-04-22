using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderItemService : IOrderItemService
    {
        IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        public async Task<OrderItem> GetOrderItemByOrderId(int orderId)
        {
            return await _orderItemRepository.GetOrderItemByOrderId(orderId);

        }
        public async Task<OrderItem> CreateOrderItem(OrderItem orderItem)
        {
            return await _orderItemRepository.CreateOrderItem(orderItem);

        }
        public async Task<List<OrderItem>> GetOrderItems()
        {
            return await _orderItemRepository.GetOrderItems();

        }
    }
}
