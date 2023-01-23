using HH2;
using Data.Exeptions;
using AutoMapper;
using Domain.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HH2.Entities;

namespace Data.Services
{

    public class UserServices : IUserServices
    {
        private readonly HHDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILog _logger;
        public UserServices(HHDbContext helpHomeDbContext, IMapper mapper, ILog logger)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;
            _logger = logger;
        }



        public async Task<IEnumerable<UserDto>> GetAllOfferentsAsync()
        {
            _logger.Info($"Offerents GET AllOfferents action invoked");
            var offerents = await _context.Users
    .Where(u => u.RoleId == 2)
    .Select(u => new UserDto { Id = u.Id, Name = u.Name, OfferDtos = _mapper.Map<List<OfferDto>>(u.Offers) })
    .ToListAsync();
            
           
            if (offerents is null)
            {
                throw new NotFoundException("Offerents not found");
            }
            else
            {
                return offerents;
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllSeekersAsync()
        {
            _logger.Info($"Seekers GET AllOfferents action invoked");
            var  seekers=  await _context.Users
                .Where(u => u.RoleId == 1)
                .Select(u => new UserDto { Id = u.Id, Name = u.Name, OfferDtos = _mapper.Map<List<OfferDto>>(u.Offers) })
                .ToListAsync();

            if (seekers is null)
            {
                throw new NotFoundException("Seekers not found");
            }
            else
            {
  
                return seekers;
            }
        }

        public async Task<UserDto> GetById(int id)
        {
            _logger.Info($"User with id: {id} GET action invoked");
            var user = await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserDto { Id = u.Id, Name = u.Name, OfferDtos = _mapper.Map<List<OfferDto>>(u.Offers) })
                .FirstOrDefaultAsync();
            if (user is null)
            {
                throw new NotFoundException("User is not found");
            }
            else
            {
                return user;
            }
        }



        public async Task Delete(int id)
        {
            _logger.Warn($"User with id: {id} DELETE action invoked");
            var user =  await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
            {
                throw new NotFoundException("User is not found");
            }
            else
            {
                 _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                
            }
        }

        public async Task Update(UpdateUserDto dto, int id)
        {
            _logger.Info($"User with id: {id} UPDATE action invoked");
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
            {
                throw new NotFoundException("User is not found");
            }
            else
            {
              
                user.Name = dto.Name;
                user.Email = dto.Email;
                user.PhoneNumber = dto.PhoneNumber;
               

               await _context.SaveChangesAsync();
               

            }

        }


    }
}



