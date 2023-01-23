using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Data.Services
{
    public interface IUserServices
    {

        Task<IEnumerable<UserDto>> GetAllOfferentsAsync();
        Task <IEnumerable<UserDto>> GetAllSeekersAsync();
        Task <UserDto> GetById(int id);
        Task Delete(int id);
        Task  Update(UpdateUserDto dto, int id);
        
    }
}

