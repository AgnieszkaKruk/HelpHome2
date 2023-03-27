using FluentAssertions;
using HH2;
using HH2.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Security.Policy;

namespace HH2Tests.Api.IntegrationTests
{
    public class OfferControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _client;
        private WebApplicationFactory<Program> _factory;

        public OfferControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbcontextOptions = services.FirstOrDefault(s => s.ServiceType == typeof(HHDbContext));
                    services.Remove(dbcontextOptions);
                    services.AddDbContext<HHDbContext>(options => options.UseInMemoryDatabase("Test"));
                });
            });

            _client = _factory.CreateClient();
            
        }

        private void AddOfferToInMemoryDatabase(Offer offer)
        {
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var _dbContext = scope.ServiceProvider.GetService<HHDbContext>();

            _dbContext.Offers.Add(offer);

            _dbContext.SaveChanges();
        }

        [Theory]
        [InlineData("api/offers")]
        [InlineData("api/offers/seekers")]
        public async Task GetAllOfferentsFromOfferentsAsync_ReturnsOk(string url)
        {
            var response = await _client.GetAsync(url);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]

        public async Task GetOfferByIdAsync_ForExistingData_ReturnsOk()
        {
            Offer offer1 = new Offer() { Name = "Sprzątanie", PriceOffer = 100, offerType = Domain.Utils.OfferType.Sprzątanie, Description = "sdssd", AddressId =2, UserId=2 };
          
            AddOfferToInMemoryDatabase(offer1);
         

            var response = await _client.GetAsync("api/offers/" + offer1.Id);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task GetOfferByIdAsync_ForNonExistingData_ReturnsNotFound()
        {
            
            var response = await _client.GetAsync("api/offers/3435");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task GetOffersFromUserById_ForExistingData_ReturnsOk()
        {

            User user = new User { Name = "Aga", Email = "aga@aga", PasswordHash = "12#$%^", PhoneNumber = "444555666", RoleId = 1 };   
            
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var _dbContext = scope.ServiceProvider.GetService<HHDbContext>();

            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            var response = await _client.GetAsync("api/offers/user/" + user.Id);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
    }
}
