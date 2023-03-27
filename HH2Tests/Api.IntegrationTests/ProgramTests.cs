using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;

namespace HH2Tests.Api.IntegrationTests
{
    public class ProgramTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private List<Type> _controllerTypes;
        private WebApplicationFactory<Program> _factory;
        
        public ProgramTests(WebApplicationFactory<Program> facory)
        {
            _controllerTypes = typeof(Program)
                .Assembly
                .GetTypes()
                .Where(c => c.IsSubclassOf(typeof(ControllerBase)))
                .ToList();

            _factory = facory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    _controllerTypes.ForEach(c => services.AddScoped(c));
                });
            });           
       
            
        }

        [Fact]

        public void ControllersServices_ForControllers_RegisterAllDependencies()
        {
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();

            _controllerTypes.ForEach(c =>
            {
                var controller = scope.ServiceProvider.GetService(c);
                controller.Should().NotBeNull();

            });

        }
    }
}
