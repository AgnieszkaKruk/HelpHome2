using Domain.Entities;

namespace HH2.Entities
{
    public class Offerent : User
    {

        public List<Address> Addresses { get; set; } = new List<Address>();
        public virtual List<Seeker> BlockedSeekers { get; set; } = new List<Seeker>();
        public List<Event> Events { get; set; } = new List<Event>();


    }
}


