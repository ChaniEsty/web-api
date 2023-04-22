using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.GetOrderById(id);

        }
        public async Task<Order> CreateOrder(Order order)
        {
            return await _orderRepository.CreateOrder(order);

        }
        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();

        }
    }
}

