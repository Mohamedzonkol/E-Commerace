using e_commerce.Configrution;
using e_commerce.Models;
using e_commerce.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Servies
{
    public class ProductServies :IProductServies
    {
        private readonly AppDbContext context;
 

        public ProductServies(AppDbContext _context)
        {
            context = _context;
    
        }
        public async Task Create(Product newProduct) {
        
        await context.Products.AddAsync(newProduct);
        await context.SaveChangesAsync();
        }
        public async Task Delete(Product Product)
        {
             context.Products.Remove(Product);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Product>> getByGatagory(int id) {
            return await context.Products.Where(x => x.CatagoryId == id).ToListAsync();
        }
        public async Task<IEnumerable<Product>> getAll()
        {
            return await context.Products.ToListAsync();

        }
        public async Task<IEnumerable<Product>> getAll(int id)
        {
            if (id == 0)
            {
                return await context.Products.ToListAsync();
            }
            return await context.Products.Where(p => p.CatagoryId == id).ToArrayAsync();
        }

        public async Task<Product> getById(int id)
        {
            return await context.Products.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<string> getCatagory(int id)
        {
            Catagory catagory= await context.Catagories.SingleOrDefaultAsync(x => x.Id == id);
            return catagory.Name;
        }
        public async Task<string> getOffer(int id)
        {
            Offer offer = await context.Offers.SingleOrDefaultAsync(x => x.Id == id);
            return offer.Name;
        }
        public async Task<bool> isVaildCatagory(int id) { 
        
        return await context.Products.AnyAsync(x=>x.Id==id);
        }
        public async Task<bool> isVaildStock(int id) {
            return await context.Products.AnyAsync(x => x.Id == id);
        }
        public async Task<bool> isVaildOffer(int id) {
            return await context.Products.AnyAsync(x => x.Id == id);
        }
        public async Task Update(int id,Product product, byte[] Photo) {
          
            await Mapping(id,product,Photo);
            await context.SaveChangesAsync();
            }
        public async Task Update(int id, Product product)
        {
            await Mapping(id, product,null);
            await context.SaveChangesAsync();
        }
        public async Task Mapping(int id, Product product, byte[] Photo) {
            Product old = await getById(id);
            if (Photo is null)
            {
                old.Photo = old.Photo;
            }
            else
            {
                old.Photo = Photo;
            }
            old.Name = product.Name;
            old.Description = product.Description;
            old.Price = product.Price;
            old.CatagoryId = product.CatagoryId;
            old.OfferId = product.OfferId;
            old.Create_at = DateTime.Now;
        }
    }

    }

