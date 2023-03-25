using FluentAssertions;
using HH2;
using HH2.Entities;
using HH2Tests.Api.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

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
                                services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                                services.AddDbContext<HHDbContext>(options => options.UseInMemoryDatabase("HHDb"));
                            });
                        });
            _httpClient = _factory.CreateClient();
        }

       private void AddUserToInMemoryDatabase(User user)
        {
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var _dbContext = scope.ServiceProvider.GetService<HHDbContext>();

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
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
        public async Task GetById_WithExistingData_returnOkResult()
        {
            var user = new User { Id = 100, Name = "Aga", Email = "aga@aga", PasswordHash = "12#$%^", PhoneNumber = "444555666" };

            AddUserToInMemoryDatabase(user);

            var response = await _httpClient.GetAsync("api/users/" + user.Id);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Delete_DeleteExistingData_ReturnNoContentResult()
        {
            var user = new User { Id = 101, Name = "Ewa", Email = "ewa@ewa", PasswordHash = "12#$%^", PhoneNumber = "444555666" };

            AddUserToInMemoryDatabase(user);

            var response = await _httpClient.DeleteAsync("api/users/" + user.Id);
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Put_WithValidModel_ReturnsOkResult()
        {
            var user = new User { Id = 104, Name = "Michał", Email = "michał@michał", PasswordHash = "12#$%^", PhoneNumber = "444555666" };

            AddUserToInMemoryDatabase(user);

            var updatedUser = new User { Id = 104, Name = "Michał", Email = "michał@gmail.com", PasswordHash = "12#$%^", PhoneNumber = "123456789" };

            var httpContent = updatedUser.ToJsonToHttpContent();
            var response = await _httpClient.PutAsync("api/users/" + user.Id,httpContent);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Put_withInvalidmodel_ReturnsBadRequestResult()
        {
            var user = new User { Id = 110, Name = "Jacek", Email = "jacek@jacek", PasswordHash = "12#$%^", PhoneNumber = "444555666" };

            AddUserToInMemoryDatabase(user);

            var updatedUser = new User { Id = 104, PasswordHash = "12#$%^", PhoneNumber = "123456789" };

            var httpContent = updatedUser.ToJsonToHttpContent();
            var response = await _httpClient.PutAsync("api/users/" + user.Id, httpContent);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }








    }
}
