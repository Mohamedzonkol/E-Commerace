using e_commerce.Configrution;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Servies
{
    public class OrderServies : IOrderServies
    {

        private readonly AppDbContext context;

        public OrderServies(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<int> CreateOrderDeteils(OrderDeteils newOrderDetails)
        {
            await context.OrderDeteils.AddAsync(newOrderDetails);
            await context.SaveChangesAsync();
            return newOrderDetails.Id;
        }
        public async Task CreateOrder(Order newOrder)
        {
            await context.Orders.AddAsync(newOrder);
            await context.SaveChangesAsync();
        }
        public async Task DeleteOrder(OrderDeteils Order)
        {
            context.OrderDeteils.Remove(Order);
            await context.SaveChangesAsync();
        }
        public async Task<OrderDeteils> getById(int id)
        {
            return await context.OrderDeteils.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<IEnumerable<Order>> getOrderItem(int orderId)
        {
            return await context.Orders.Where(c => c.OrderDetailsId == orderId).ToListAsync();
        }
        //public async Task DecreaseStock(int productId, int quantity)
        //{
        //    var product = await context.Products.SingleOrDefaultAsync(p => p.Id == productId);
        //    var stock = await context.Stocks.SingleOrDefaultAsync(s => s.Id == product.StockId);

        //    stock.Quantity -= quantity;
        //    context.Stocks.Update(stock);
        //    await context.SaveChangesAsync();

        //}

        //public async Task IncreaseStock(int productId, int quantity)
        //{
        //    var product = await context.Products.SingleOrDefaultAsync(p => p.Id == productId);
        //    var stock = await context.Stocks.SingleOrDefaultAsync(s => s.Id == product.StockId);

        //    stock.Quantity += quantity;
        //    context.Stocks.Update(stock);
        //    await context.SaveChangesAsync();

        //}

        public async Task<IEnumerable<OrderDeteils>> MyOrders(string userId)
        {
            return await context.OrderDeteils.Where(o => o.UserID == userId).ToListAsync();
        }
    }
}
