using e_commerce.Models;

namespace e_commerce.Servies
{
    public interface IOrderServies
    {
        Task CreateOrder(Order newOrder);
        Task<int> CreateOrderDeteils(OrderDeteils newOrderDetails);
        //Task DecreaseStock(int productId, int quantity);
        Task DeleteOrder(OrderDeteils Order);
        Task<OrderDeteils> getById(int id);
        Task<IEnumerable<Order>> getOrderItem(int orderId);
        //Task IncreaseStock(int productId, int quantity);
        Task<IEnumerable<OrderDeteils>> MyOrders(string userId);
    }
}