using e_commerce.Models;

namespace e_commerce.Servies
{
    public interface IOfferServies
    {
        Task Create(Offer newOffer);
        Task Delete(Offer offer);
        Task<IEnumerable<Offer>> getAll();
        Task<Offer> getById(int id);
        Task<Offer> getByName(string name);
        Task Update(Offer offer);
    }
}