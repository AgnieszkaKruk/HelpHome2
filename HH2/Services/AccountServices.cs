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
            User newUser;

            if (dto.RoleId == 1) // Seeker
            {
                var newSeeker = new Seeker()
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber
                };

                var newPassword = _passwordHasher.HashPassword(newSeeker, dto.Password);
                newSeeker.PasswordHash = newPassword;

                newUser = newSeeker;
            }
            else if (dto.RoleId == 2) // Offerent
            {
                var newOfferent = new Offerent()
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber
                };

                var newPassword = _passwordHasher.HashPassword(newOfferent, dto.Password);
                newOfferent.PasswordHash = newPassword;

                newUser = newOfferent;
            }
            else
            {
                
                throw new ArgumentException("Invalid roleId value.");
            }

            newUser.RoleId = dto.RoleId;
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
