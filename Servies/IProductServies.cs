using e_commerce.Models;
using e_commerce.ViewModel;

namespace e_commerce.Servies
{
    public interface IProductServies
    {
        Task Create(Product newProduct);
        Task Delete(Product Product);
        Task<IEnumerable<Product>> getAll();
        Task<IEnumerable<Product>> getAll(int id);

        Task<IEnumerable<Product>> getByGatagory(int id);
        Task<Product> getById(int id);
        Task<string> getCatagory(int id);
        Task<string> getOffer(int id);
        Task<bool> isVaildCatagory(int id);
        Task<bool> isVaildOffer(int id);
        Task<bool> isVaildStock(int id);
        Task Update(int id,Product product, byte[] Photo);
        Task Update(int id, Product product);
    }
}