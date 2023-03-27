using Data.Services;
using Domain.Models;
using FluentAssertions;
using HH2;
using HH2.Entities;
using HH2Tests.Api.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HH2Tests.Api.IntegrationTests
{
    public class AccountControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _httpClient;
        private Mock<IAccountServices> _accountServicesMock = new Mock<IAccountServices>();

        public AccountControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.
                        WithWebHostBuilder(builder =>
                        {
                            builder.ConfigureServices(services =>
                            {
                                var DbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<HHDbContext>));
                                services.Remove(DbContextOptions);
                                services.AddSingleton<IAccountServices>(_accountServicesMock.Object);
                                services.AddDbContext<HHDbContext>(options => options.UseInMemoryDatabase("HHDb"));
                            });
                        });
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task RegisterUser_ForValidModel_ReturnsOk()
        {
            RegisterDto dto = new RegisterDto {Name = "Agnieszka", Email = "Aga@aga", Password = "1234567", ConfirmPassword = "1234567", PhoneNumber = "123456789", RoleId = 1 };
            var httpContent = dto.ToJsonToHttpContent();
            var response = await _httpClient.PostAsync("api/account/register", httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        }


        [Fact] //za krótkie hasło
        public async Task RegisterUser_ForInValidModel_ReturnsBadRequest()
        {
            RegisterDto dto = new RegisterDto { Name = "Agnieszka", Email = "Aga@aga", Password = "123", ConfirmPassword = "123", PhoneNumber = "123456789", RoleId = 1 };
            var httpContent = dto.ToJsonToHttpContent();
            var response = await _httpClient.PostAsync("api/account/register", httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

        }

        [Fact]
        public async Task Login_ForRegisterUser_ReturnsOk()
        {
            User user = new User() { Name = "Agnieszka", Email = "aga@aga", PhoneNumber = "12345675656", RoleId = 1, Id = 123 };
            _accountServicesMock.Setup(e=>e.AutenticateUser(It.IsAny<LoginDto>())).Returns(user);
                                  
            LoginDto dto = new LoginDto { Email = "aga@aga", Password = "1234567" };
            var httpContent = dto.ToJsonToHttpContent();
            var response = await _httpClient.PostAsync("api/account/login", httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Login_ForUnRegisterUser_ReturnsUnauthorized()
        {
            
            LoginDto dto = new LoginDto { Email = "aga1@aga", Password = "1234567" };
            var httpContent = dto.ToJsonToHttpContent();
            var response = await _httpClient.PostAsync("api/account/login", httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
