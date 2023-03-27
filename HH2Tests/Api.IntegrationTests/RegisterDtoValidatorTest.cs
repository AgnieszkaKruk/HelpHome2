using Data.Validators;
using Domain.Models;
using FluentAssertions;
using FluentValidation.TestHelper;
using HH2;
using HH2.Entities;
using HH2Tests.Api.IntegrationTests.DataForTests;
using Microsoft.EntityFrameworkCore;

namespace HH2Tests.Api.IntegrationTests
{
    public class RegisterDtoValidatorTest
    {
        private HHDbContext _dbContext;

        public RegisterDtoValidatorTest()
        {
            var builder = new DbContextOptionsBuilder<HHDbContext>();
            builder.UseInMemoryDatabase("Test");

            _dbContext = new HHDbContext(builder.Options);
            Seed();

        }

        public void Seed()
        {
            var users = new List<User>()
            {
                new User(){ Name = "Test1", PasswordHash = "Test1", PhoneNumber = "222333444", Email = "test1@test1"},
                new User(){ Name = "Test3", PasswordHash = "Test3", PhoneNumber = "222333444", Email = "test3@test3"},
            };
            _dbContext.Users.AddRange(users);
            _dbContext.SaveChanges();


        }
        [Fact]
        public void Validate_forValidModel_ReturnsSukcess()
        {
           var model = new RegisterDto() { Name = "test", Email = "test@test", Password = "1111111", ConfirmPassword = "1111111", PhoneNumber = "123456789", RoleId = 1 };


            var validator = new RegisterDtoValidator(_dbContext);
           var result = validator.TestValidate(model);
           
           result.ShouldNotHaveAnyValidationErrors();


        }

        
        [Theory]
        [ClassData(typeof(RegisterDtoValidatorTestsData))]
        public void Validate_forInValidModel_ReturnsFailure(RegisterDto registerDto)
        {
           // var model = new RegisterDto() { Name = "test", Email = "test1@test1", Password = "1111111", ConfirmPassword = "1111111", PhoneNumber = "123456789", RoleId = 1 };
           var validator = new RegisterDtoValidator(_dbContext);
            var result = validator.TestValidate(registerDto);
            result.ShouldHaveAnyValidationError();

          
            
        }
    }
}