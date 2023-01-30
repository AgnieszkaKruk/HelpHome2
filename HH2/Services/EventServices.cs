using AutoMapper;
using Data.Exeptions;
using Domain.Entities;
using HH2;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class EventServices : IEventServives
    {
        private readonly HHDbContext _context;
        private readonly ILog _logger;

        public EventServices(HHDbContext context, ILog logger)
        {
            _context = context;
            _logger = logger;
            
        }

        public async Task<IEnumerable<Event>>GetAllEventsAsync(DateTime start, DateTime end)
        {
            _logger.Info($"Events GET AllEventsAsync action invoked");
            var events = await _context.Events.ToListAsync();
    

            if (events is null)
            {
                throw new NotFoundException("Events not found");
            }
            else
            {
                return events;
            }
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            _logger.Info($"Event with {id} GET GetEventByIdAsync invoked");
            var eventt = await _context.Events.FirstOrDefaultAsync(o => o.Id == id);
            if (eventt is null)
            {
                throw new NotFoundException("Event not found");
            }
            else
            {  
                return eventt;
            }
        }

        public async Task<IEnumerable<Event>> GetEventsFromUserById(int id)
        {
            _logger.Info($"User with id: {id} GET GetEventsFromUserById action invoked");
            var userEvents = await _context.Events
                .Where(u=>u.UserId == id)
                .ToListAsync();
            if (userEvents is null)
            {
                throw new NotFoundException("User hasn't got any events");
            }
            else
            {   
                return userEvents;
            }
        }


        public async Task AddEvent(Event eventt, int id)
        {
            _logger.Info($"User with id: {id} POST AddEvent action invoked");
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
            {
                throw new NotFoundException("User is not found");
            }
            else
            {
                var newEvent = new Event { Start = eventt.Start, End = eventt.End, Color = eventt.Color, Text = eventt.Text, Offerent = eventt.Offerent, UserId = id }; 
                _context.Events.Add(newEvent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEvent(int id)
        {
            _logger.Warn($"Event with id: {id} DELETE DeleteEvent action invoked");
            var eventt = await _context.Events.FirstOrDefaultAsync(u => u.Id == id);
            if (eventt is null)
            {
                throw new NotFoundException("Event is not found");
            }
            else
            {
                _context.Events.Remove(eventt);
                await _context.SaveChangesAsync();

            }
        }

        public async Task UpdateEvent(Event newevent, int id)
        {
            _logger.Info($"Event with id: {id} UPDATE UpdateEvent action invoked");
            var eventt = await _context.Events.FirstOrDefaultAsync(u => u.Id == id);
            if (eventt is null)
            {
                throw new NotFoundException("Event is not found");
            }
            else
            {

                eventt.Start = newevent.Start;
                eventt.End = newevent.End;
                eventt.Text = newevent.Text;
                eventt.Color = newevent.Color;
                eventt.Offerent = newevent.Offerent;
                eventt.UserId = newevent.UserId;

                await _context.SaveChangesAsync();


            }

        }


    }
}
