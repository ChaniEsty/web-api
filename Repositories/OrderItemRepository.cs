using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        EstyWebApiContext _estyWebApiContext;

        public OrderItemRepository(EstyWebApiContext estyWebApiContext)
        {
            _estyWebApiContext = estyWebApiContext;
        }
        public async Task<List<OrderItem>> GetOrderItems()
        {
            return await _estyWebApiContext.OrderItems.Include(orderItem => orderItem.Product).Include(orderItem => orderItem.Order).ToListAsync();

        }
        public async Task<OrderItem> GetOrderItemByOrderId(int orderId)
        {
            return await _estyWebApiContext.OrderItems.FindAsync(orderId);
            // return await _estyWebApiContext.OrderItems.Include(orderItem => orderItem.Product).Include(orderItem=> orderItem.Order).FindAsync(orderId);
        }
        public async Task<OrderItem> CreateOrderItem(OrderItem orderItem)
        {
            await _estyWebApiContext.AddAsync(orderItem);
            await _estyWebApiContext.SaveChangesAsync();
            return orderItem;
        }
    }
}
