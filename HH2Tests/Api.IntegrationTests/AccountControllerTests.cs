using Domain.Models;
using FluentAssertions;
using HH2;
using HH2Tests.Api.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace HH2Tests.Api.IntegrationTests
{
    public class AccountControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _httpClient;

        public AccountControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.
                        WithWebHostBuilder(builder =>
                        {
                            builder.ConfigureServices(services =>
                            {
                                var DbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<HHDbContext>));
                                services.Remove(DbContextOptions);
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
    }
}
