using FluentAssertions;
using HH2;
using HH2.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HH2Tests.Api.IntegrationTests
{
    public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly HttpClient _httpClient;
        private WebApplicationFactory<Program> _factory;

        public UserControllerTests(WebApplicationFactory<Program> factory)
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

        [Theory]
        [InlineData("api/users/offerents")]
        [InlineData("api/users/seekers")]

        public async Task GetUsers_WithExistingData_ReturnsOkResult(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task GetById_WithNonExistingUser_ReturnsNotFoundResult()
        {
            var response = await _httpClient.GetAsync("api/users/876");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Fact]
        public async Task Delete_DeleteExistingData_ReturnNoContentResult()
        {
            var user = new User { Id = 101, Name = "Ewa", Email = "ewa@ewa", PasswordHash = "12#$%^", PhoneNumber = "444555666" };

            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var _dbContext = scope.ServiceProvider.GetService<HHDbContext>();

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            var response = await _httpClient.DeleteAsync("api/users/" + user.Id);
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }


        [Fact]
        public async Task GetById_WithExistingData_returnOkResult()
        {
            var user = new User { Id = 100, Name = "Aga", Email = "aga@aga", PasswordHash = "12#$%^", PhoneNumber = "444555666" };

            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var _dbContext = scope.ServiceProvider.GetService<HHDbContext>();

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();


            var response = await _httpClient.GetAsync("api/users/" + user.Id);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }








    }
}
