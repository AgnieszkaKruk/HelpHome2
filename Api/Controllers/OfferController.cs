using Data.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class OfferController : Controller
    {


        private readonly IOfferServices _offerServices;

        public OfferController(IOfferServices offerServices)
        {
            _offerServices = offerServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OfferDto>>> GetAllOfferentsFromOfferentsAsync()
        {
            var offers = await _offerServices.GetAllOffersFromOfferentsAsync();
            return Ok(offers);
        }

        [HttpGet("seekers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OfferDto>>> GetAllOfferentsFromSeekersAsync()
        {
            var offers = await _offerServices.GetAllOffersFromSeekersAsync();
            return Ok(offers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OfferDto>> GetOfferByIdAsync(int id)
        {
            var offer = await _offerServices.GetOfferByIdAsync(id);
            return Ok(offer);
        }


        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDto>> GetOffersFromUserById([FromRoute] int userId)
        {
            var offers = await _offerServices.GetOffersFromUserById(userId);
            return Ok(offers);
        }

        [HttpPost("user/{userId}")]
       [Authorize]
        public async Task<ActionResult<OfferDto>> AddOffer(OfferDto dto, [FromRoute] int userId)
        {
            await _offerServices.AddOffer(dto, userId);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _offerServices.DeleteOffer(id);
            return NoContent();

        }



        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] OfferDto dto, [FromRoute] int id)
        {
            await _offerServices.UpdateOffer(dto, id);
            return Ok();
        }
    }
}
