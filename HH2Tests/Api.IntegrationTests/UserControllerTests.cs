using Data.Services;
using Domain.Models;
using HelpHomeApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System.Net;

namespace HH2Tests.Api.IntegrationTests
{
    public class UserControllerTests
    {
        private readonly Mock<IUserServices> _userServiecesMock;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _userServiecesMock = new Mock<IUserServices>();
            _userController = new UserController(_userServiecesMock.Object);
        }

        [Fact]
        public async Task GetUsers_ReturnsOkResult()
        {
            var expectedStatus = HttpStatusCode.OK;
           
            var result = await _userController.GetAllOfferentsAsync();

            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(expectedStatus, (HttpStatusCode)okResult.StatusCode);
        }
    }
    }
