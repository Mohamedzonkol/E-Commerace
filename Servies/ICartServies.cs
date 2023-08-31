using e_commerce.Models;

namespace e_commerce.Servies
{
    public interface ICartServies
    {
        Task Create(Cart newCart);
        Task Delete(Cart cart);
        IEnumerable<Cart>GetAll(string userId);
        Task<Cart> GetCartById(int id);
         Task<Cart> GetUserCart(int productId, string UserId);
        Task Update(Cart cart);
    }
}