using Entities;

namespace Services
{
    public interface IOrderItemService
    {
        
        Task<OrderItem> GetOrderItemByOrderId(int orderId);
        Task<List<OrderItem>> GetOrderItems();
    }
}