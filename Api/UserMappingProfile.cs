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
            ////CreateMap<CreateSeekerDto, Seeker>();           
            //CreateMap<CreateCarpetWashingDto, CarpetWashing>();
            //CreateMap<CarpetWashing, CarpetWashingDto>();
            //CreateMap<Cleaning, CleaningDto>();
            //CreateMap<WindowsCleaning, WindowsCleaningDto>();
            //CreateMap<CreateWindowsCleaningDto, WindowsCleaning>();
            //CreateMap<CreateCleaningDto, Cleaning>();

        }
    }
}

