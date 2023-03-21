using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);
        Task<List<Order>> GetOrders();
        Task<Order> GetOrderById(int id);
    }
}