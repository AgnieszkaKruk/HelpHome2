using AutoMapper;
using Domain.Models;
using HH2.Entities;

namespace Api
{

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {

            CreateMap<User, UserDto>();     
            CreateMap<Offer, OfferDto>();
            CreateMap<OfferDto, Offer>();
           

        }
    }
}

