using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        EstyWebApiContext _estyWebApiContext;

        public OrderRepository(EstyWebApiContext estyWebApiContext)
        {
            _estyWebApiContext = estyWebApiContext;
        }
        public async Task<List<Order>> GetOrders()
        {
            return await _estyWebApiContext.Orders.Include(order => order.User).ToListAsync();
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _estyWebApiContext.Orders.FindAsync(id);
            // return await _estyWebApiContext.Products.Include(product => product.Category).FindAsync(id);
        }
        public async Task<Order> CreateOrder(Order order)
        {
            await _estyWebApiContext.Orders.AddAsync(order);
            await _estyWebApiContext.SaveChangesAsync();
            return order;

        }
    }
}

