using Data.Exeptions;
using Domain.Models;
using HH2;
using HH2.Entities;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;

namespace Data.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly HHDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountServices(HHDbContext helpHomeDbContext, IPasswordHasher<User> passwordHasher)
        {
            _context = helpHomeDbContext;
            _passwordHasher = passwordHasher;
        }

        public void RegisterUser(RegisterDto dto)
        {
            var newUser = new User()
            {
                Name = dto.Name,
                Email = dto.Email,
                RoleId = dto.RoleId,
                PhoneNumber = dto.PhoneNumber,
            };

            var newPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = newPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public User AutenticateUser(LoginDto dto)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == dto.Email);

            if (user == null)
            {
                throw new BadRequestException("Invalid login or password");
            }

            var userResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (userResult != PasswordVerificationResult.Success)
            {
                throw new BadRequestException("Invalid login or password");
            }

            return user;
        }
    }
}
