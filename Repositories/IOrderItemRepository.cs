using Entities;

namespace Repositories
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> CreateOrderItem(OrderItem orderItem);
        Task<OrderItem> GetOrderItemByOrderId(int orderId);
        Task<List<OrderItem>> GetOrderItems();
    }
}