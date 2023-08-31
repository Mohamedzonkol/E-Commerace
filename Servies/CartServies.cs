using e_commerce.Configrution;
using e_commerce.Models;
using e_commerce.Servies;
using e_commerce.Configrution;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace First_MVC.Servies
{
    public class CartServies : ICartServies
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> usermanager;

        public CartServies(AppDbContext _context, UserManager<IdentityUser> _usermanager)
        {
             context =_context;
            usermanager = _usermanager;
        }
        public async Task Create(Cart newCart)
        {

            await context.Carts.AddAsync(newCart);
            await context.SaveChangesAsync();
        }
        public async Task Delete(Cart cart)
        {
            context.Carts.Remove(cart);
            await context.SaveChangesAsync();
        }
        public IEnumerable<Cart> GetAll(string userId)
        {
            return  context.Carts.Where(c => c.UserID == userId).ToList();
        }
        public async Task<Cart> GetCartById(int id)
        {
            return await context.Carts.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Cart> GetUserCart(int productId, string UserId)
        {
            return await context.Carts.SingleOrDefaultAsync(c => c.ProductId == productId && c.UserID == UserId);
        }
        public async Task Update(Cart cart)
        {
            context.Carts.Update(cart);
            await context.SaveChangesAsync();
        }

    }
}
