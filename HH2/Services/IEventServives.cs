using Domain.Entities;

namespace Data.Services
{
    public interface IEventServives
    {
        Task<IEnumerable<Event>> GetAllEventsAsync(DateTime start, DateTime end);
        Task<Event> GetEventByIdAsync(int id);
        Task<IEnumerable<Event>> GetEventsFromUserById(int id);
        Task DeleteEvent(int id);
        Task UpdateEvent(Event eventt, int id);
        Task AddEvent(Event eventt, int id);




    }
}
