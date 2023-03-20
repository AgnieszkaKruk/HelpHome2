using Domain.Entities;

namespace Data.Validators
{
    public static class EventDateValidator
    {

        /// Returns true value if the input EVENT DATE are not overlapping

        public  static bool ValidateOverlapping(List<Event> events, Event newEvent)
        {
            if (events == null || !events.Any()) return true;


            var overlappingEvents = events
                .FirstOrDefault(ev => newEvent.Start.Date >= ev.Start.Date && newEvent.Start.Date <= ev.End.Date
                                    || newEvent.End.Date >= ev.End.Date && newEvent.End.Date <= ev.End.Date);

            if (overlappingEvents != null) return false;


            var outerOverlappingDateEvents = events
                .FirstOrDefault(ev => ev.Start.Date <= newEvent.Start.Date && ev.End.Date >= newEvent.End.Date);

            if (outerOverlappingDateEvents != null) return false;


            var innerOverlappingDateEvents = events
                .FirstOrDefault(ev => ev.Start.Date <= newEvent.End.Date && ev.Start.Date >= newEvent.End.Date
                 && ev.Start.Date <= newEvent.End.Date && ev.End.Date >= newEvent.Start.Date);


            if (innerOverlappingDateEvents != null) return false;

            return true;
        }
    }
}

