using Api.Controllers;
using Data.Services;
using Domain.Models;
using Domain.Utils;
using FluentAssertions;
using HH2;
using HH2.Entities;
using HH2Tests.Api.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;


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
                    services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
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
            Offer offer1 = new Offer() { Name = "Sprzątanie", PriceOffer = 100, offerType = Domain.Utils.OfferType.Sprzątanie, Description = "sdssd", AddressId = 2, UserId = 2 };

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



        [Fact] 
        public async Task AddOffer_WithValidModel_ReturnsOk()
        {
            Offer offer = new Offer()
            {
                Name = "Sprzątanie",
                PriceOffer = 100,
                Description = "sdssd",
                UserId = 2,
                AddressId = 5
            };

            var httpContent = offer.ToJsonToHttpContent();
            var response = await  _client.PostAsync("api/offers/user/" + offer.UserId, httpContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

       

        [Fact]
        public async Task Update_ForValidModel_ReturnsOk()
        {
            Offer offer = new Offer()
            {
                Name = "Sprzątanie",
                PriceOffer = 100,
                Description = "sdssd",
                UserId = 2,
                AddressId = 3
            };

            AddOfferToInMemoryDatabase(offer);

            Offer offerUpdated = new Offer()
            {
                Name = "Mycie okien",
                PriceOffer = 100,
                Description = "sdssd",
                UserId = 2,
                AddressId = 3
            };

            var httpContent = offerUpdated.ToJsonToHttpContent();
            var response = await _client.PutAsync("api/offers/" + offer.Id, httpContent);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    

    

        [Fact]
        public async Task Delete_DeleteExistingOffer_ReturnNoContent()
        {
            Offer offer = new Offer() { Name = "Sprzątanie", PriceOffer = 100, offerType = Domain.Utils.OfferType.Sprzątanie, Description = "sdssd", AddressId = 3, UserId = 2 };

            AddOfferToInMemoryDatabase(offer);

            var response = await _client.DeleteAsync("api/offers/" + offer.Id);
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }


    }
}
