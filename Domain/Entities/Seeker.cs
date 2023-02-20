namespace HH2.Entities
{
    public class Seeker : User
    {
        public List<Offerent> favouriteOfferents = new List<Offerent>();
        public void AddFavouriteOfferent(Offerent offerent)
        {
            favouriteOfferents.Add(offerent);
        }
    }
}


