using e_commerce.Models;

namespace e_commerce.Servies
{
    public interface ICatagoryServies
    {
        Task Create(Catagory newCatagory);
        Task Delete(Catagory Catagory);
        Task<IEnumerable<Catagory>> getAll();
        Task<Catagory> getById(int id);
        Task<Catagory> getByName(string name);

        Task Update(Catagory catagory);
    }
}