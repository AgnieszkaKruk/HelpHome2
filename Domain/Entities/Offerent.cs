using Data.Validators;
using Domain.Entities;

namespace HH2.Entities
{
    public class Offerent : User
    {

        public List<Address> Addresses { get; set; } = new List<Address>();
        public virtual List<Seeker> BlockedSeekers { get; set; } = new List<Seeker>();
        public List<Event> Events { get; set; } = new List<Event>();

        public void AddBlockedSeeker(Seeker seeker)
        {
            BlockedSeekers.Add(seeker);
        }

        public void AddEvents(List<Event> events)
        {
            Event newEvent = new Event();
            if (!EventDateValidator.ValidateOverlapping(Events, newEvent))
            {
                Events.Add(newEvent);
            }
            else
            {
                throw new Exception("This date is already booked");
            }


        }


    }
}


