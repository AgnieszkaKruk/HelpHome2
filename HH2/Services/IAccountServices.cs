using Domain.Models;
using HH2.Entities;

namespace Data.Services
{
    public interface IAccountServices
    {
        void RegisterUser(RegisterDto dto);
        User AutenticateUser(LoginDto dto);
      
    }
}
