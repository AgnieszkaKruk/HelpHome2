using Data.Validators;
using Domain.Models;
using HH2;
using HH2Tests.Api.IntegrationTests.DataForTests;
using Microsoft.EntityFrameworkCore;
using FluentValidation.TestHelper;

namespace HH2Tests.Api.IntegrationTests.Validators
{
    public class LoginDtoValidatorTest
    {
        private HHDbContext _dbContext;

        public LoginDtoValidatorTest()
        {
            var builder = new DbContextOptionsBuilder<HHDbContext>();
            builder.UseInMemoryDatabase("Test");

            _dbContext = new HHDbContext(builder.Options);

        }


        [Fact]
        public void Validate_forValidModel_ReturnsSukcess()
        {
            var model = new LoginDto() { Email = "test@test", Password = "1111111" };
            var validator = new LoginValidator(_dbContext);
            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }


        [Theory]
        [ClassData(typeof(LoginDtoValidatorTestsData))]
        public void Validate_forInValidModel_ReturnsFailure(LoginDto loginDto)
        {
            var validator = new LoginValidator(_dbContext);
            var result = validator.TestValidate(loginDto);
            result.ShouldHaveAnyValidationError();

        }
    }
}
