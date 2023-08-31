using e_commerce.Configrution;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Servies
{
    public class OfferServies : IOfferServies
    {
        private readonly AppDbContext context;

        public OfferServies(AppDbContext _context)
        {
            context = _context;
        }
        public async Task Create(Offer newOffer)
        {
            await context.Offers.AddAsync(newOffer);
            await context.SaveChangesAsync();
        }
        public async Task Delete(Offer offer)
        {
            context.Offers.Remove(offer);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Offer>> getAll()
        {
            return await context.Offers.ToListAsync();
        }
        public async Task<Offer> getById(int id)
        {
            return await context.Offers.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Offer> getByName(string name)
        {
            return await context.Offers.SingleOrDefaultAsync(c => c.Name == name);
        }

        public async Task Update( Offer offer)
        {
            context.Update(offer);
          
            await context.SaveChangesAsync();
        }
    }
}
