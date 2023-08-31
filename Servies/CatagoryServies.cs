using e_commerce.Configrution;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Servies
{
    public class CatagoryServies : ICatagoryServies
    {
        private readonly AppDbContext context;

        public CatagoryServies(AppDbContext _context)
        {
            context = _context;
        }
        public async Task Create(Catagory newCatagory)
        {

            await context.Catagories.AddAsync(newCatagory);
            await context.SaveChangesAsync();
        }
        public async Task Delete(Catagory Catagory)
        {
            context.Catagories.Remove(Catagory);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Catagory>> getAll()
        {
            return await context.Catagories.ToListAsync();
        }
        public async Task<Catagory> getById(int id)
        {
            return await context.Catagories.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Catagory> getByName(string name)
        {
            return await context.Catagories.SingleOrDefaultAsync(c => c.Name == name);
        }

        public async Task Update(Catagory catagory)
        {
             context.Update(catagory);
            await context.SaveChangesAsync();
        }
    }
}
