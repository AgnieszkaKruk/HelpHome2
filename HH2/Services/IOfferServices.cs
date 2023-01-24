using Domain.Models;

namespace Data.Services
{
    public interface IOfferServices
    {
        Task AddOffer(OfferDto dto, int id);
        Task DeleteOffer(int id);
        Task<IEnumerable<OfferDto>> GetAllOffersFromOfferentsAsync();

        Task<IEnumerable<OfferDto>> GetAllOffersFromSeekersAsync();
        Task<IEnumerable<OfferDto>> GetOffersFromUserById(int id);
        Task UpdateOffer(OfferDto dto, int id);
        Task<OfferDto> GetOfferByIdAsync(int id);
    }
}