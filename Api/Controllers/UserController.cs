
using Data.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HelpHomeApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("offerents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task <ActionResult<IEnumerable<UserDto>>> GetAllOfferentsAsync()
        {
            var offerents = await _userServices.GetAllOfferentsAsync();
            return Ok(offerents);
        }

        [HttpGet("seekers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllSeekersAsync()
        {
            var seekers = await _userServices.GetAllSeekersAsync();
            return Ok(seekers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDto>> GetById([FromRoute] int id)
        {
            var user = await _userServices.GetById(id);
            return Ok(user);
        }

    

        [HttpDelete("{id}")]
       // [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
             await _userServices.Delete(id);
            return NoContent();

        }

        [HttpPut("{id}")]
       [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update ([FromBody] UpdateUserDto dto, [FromRoute] int id)
        {
           await  _userServices.Update(dto, id);
            return Ok();
        }
    }
}

