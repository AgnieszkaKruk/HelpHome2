using Data.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventServives eventServices;

        public EventController(IEventServives eventServices)
        {
            this.eventServices = eventServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEventsAsync([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var events = await eventServices.GetAllEventsAsync(start,end);
            return Ok(events);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Event>> GetEventByIdAsync(int id)
        {
            var eventt = await eventServices.GetEventByIdAsync(id);
            return Ok(eventt);
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Event>> GetEventsFromUserById([FromRoute] int userId)
        {
            var events = await eventServices.GetEventsFromUserById(userId);
            return Ok(events);
        }


        [HttpPost("user/{userId}")]
        [Authorize]
        public async Task<ActionResult<Event>> AddEvent(Event eventt, [FromRoute] int userId)
        {
            await eventServices.AddEvent(eventt, userId);
            return Ok(eventt);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await eventServices.DeleteEvent(id);
            return NoContent();

        }

        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] Event eventt, [FromRoute] int id)
        {
            await eventServices.UpdateEvent(eventt, id);
            return Ok();
        }

    }
}
