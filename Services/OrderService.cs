using Entities;
using Microsoft.Extensions.Logging;
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
        IProductRepository _productReposirory;
        ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository, IProductRepository productReposirory)
        {
            _orderRepository = orderRepository;
            _productReposirory = productReposirory;
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.GetOrderById(id);

        }
        public async Task<Order> CreateOrder(Order order)
        {
           
            int sum = 0;
            foreach (var item in order.OrderItems)
            {
                Product product=await _productReposirory.GetProductById(item.ProductId);
                sum += (product.Price*item.Quentity);
            }
            if (order.OrderSum != sum)
                _logger.LogInformation("client changed sum check him out");
                
            order.OrderSum = sum;
            return await _orderRepository.CreateOrder(order);

        }
        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();

        }
    }
}

