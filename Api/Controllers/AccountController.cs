using Data.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _accountServices;

        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto dto)
        {
            _accountServices.RegisterUser(dto);
            return StatusCode(200);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = _accountServices.AutenticateUser(dto);

            if (user == null)
            {
                return Unauthorized();
            }

            var claimsOfferent = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role,$"{user.Role}"),
            };

            var identityOfferent = new ClaimsIdentity(claimsOfferent, CookieAuthenticationDefaults.AuthenticationScheme);
            var principalOfferent = new ClaimsPrincipal(identityOfferent);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principalOfferent, new AuthenticationProperties { IsPersistent = dto.RememberLogin });

            Console.WriteLine("Logowanie się udało");

            return Ok(user);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}
