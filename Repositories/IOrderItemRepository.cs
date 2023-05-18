using Entities;

namespace Repositories
{
    public interface IOrderItemRepository
    {
        
        Task<OrderItem> GetOrderItemByOrderId(int orderId);
        Task<List<OrderItem>> GetOrderItems();
    }
}