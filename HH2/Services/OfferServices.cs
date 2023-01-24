using AutoMapper;
using Data.Exeptions;
using Domain.Models;
using HH2;
using HH2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class OfferServices : IOfferServices
    {
        private readonly HHDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILog _logger;
        public OfferServices(HHDbContext helpHomeDbContext, IMapper mapper, ILog logger)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;
            _logger = logger;
        }



        public async Task<IEnumerable<OfferDto>> GetAllOffersFromOfferentsAsync()
        {
            _logger.Info($"Offers GET AllOffersFromOfferentsAsync action invoked");
            var offers = await _context.Offers.Where(p =>p.User.Role.Name == "Offerent")
    .Select(u => new OfferDto { Name = u.Name, Description = u.Description, Address = u.Address, CreatedDate = u.CreatedDate, UpdateDate = u.UpdateDate, PriceOffer = u.PriceOffer })
    .ToListAsync();

            if (offers is null)
            {
                throw new NotFoundException("Offers not found");
            }
            else
            {
                return offers;
            }
        }

        public async Task<IEnumerable<OfferDto>> GetAllOffersFromSeekersAsync()
        {
            _logger.Info($"Offers GET AllOffersFromSeekersAsync action invoked");
            var offers = await _context.Offers.Where(p => p.User.Role.Name == "Seeker")
    .Select(u => new OfferDto { Name = u.Name, Description = u.Description, Address = u.Address, CreatedDate = u.CreatedDate, UpdateDate = u.UpdateDate, PriceOffer = u.PriceOffer })
    .ToListAsync();

            if (offers is null)
            {
                throw new NotFoundException("Offers not found");
            }
            else
            {
                return offers;
            }
        }

        public async Task<OfferDto> GetOfferByIdAsync(int id)
        {
            _logger.Info($"Offer with {id} GET GetOfferByIdAsync invoked");
            var offer = await _context.Offers.FirstOrDefaultAsync(o => o.Id == id);
            if (offer is null)
            {
                throw new NotFoundException("Offer not found");
            }
            else
            {
                var offerDto = _mapper.Map<OfferDto>(offer);
                return offerDto;
            }
        }



            public async Task<IEnumerable<OfferDto>> GetOffersFromUserById(int id)
            {
                _logger.Info($"User with id: {id} GET GetOffersFromUserById action invoked");
                var userOffers = await _context.Users
                    .Where(u => u.Id == id)
                    .SelectMany(u => u.Offers)
                    .ToListAsync();
                if (userOffers is null)
                {
                    throw new NotFoundException("User hasn't got any offers");
                }
                else
                {
                    var userOffersResult = _mapper.Map<IEnumerable<OfferDto>>(userOffers);
                    return userOffersResult;
                }
            }



            public async Task AddOffer(OfferDto dto, int id)
            {
                _logger.Info($"User with id: {id} POST AddOffer action invoked");
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user is null)
                {
                    throw new NotFoundException("Offer is not found");
                }
                else
                {
                    var newOfferDto = new OfferDto { Name = dto.Name, Description = dto.Description, Address = dto.Address, PriceOffer = dto.PriceOffer, CreatedDate = dto.CreatedDate, UserId = id };
                    var newOffer = _mapper.Map<Offer>(newOfferDto);
                    _context.Offers.Add(newOffer);
                    

                    await _context.SaveChangesAsync();
                }
            }



            public async Task DeleteOffer(int id)
            {
                _logger.Warn($"Offer with id: {id} DELETE DeleteOffer action invoked");
                var offer = await _context.Offers.FirstOrDefaultAsync(u => u.Id == id);
                if (offer is null)
                {
                    throw new NotFoundException("Offer is not found");
                }
                else
                {
                    _context.Offers.Remove(offer);
                    await _context.SaveChangesAsync();

                }
            }

            public async Task UpdateOffer(OfferDto dto, int id)
            {
                _logger.Info($"Offer with id: {id} UPDATE UpdateOffer action invoked");
                var offer = await _context.Offers.FirstOrDefaultAsync(u => u.Id == id);
                if (offer is null)
                {
                    throw new NotFoundException("User is not found");
                }
                else
                {

                    offer.Name = dto.Name;
                    offer.Description = dto.Description;
                    offer.PriceOffer = dto.PriceOffer;
                    offer.Address = dto.Address;
                    offer.UpdateDate = dto.UpdateDate;

                    await _context.SaveChangesAsync();


                }

            }


        }
    }
