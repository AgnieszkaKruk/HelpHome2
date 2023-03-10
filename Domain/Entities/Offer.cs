using Domain.Utils;
using HH2.Utils;

namespace HH2.Entities
{

    public class Offer
    {
        public int Id { get; set; }
        public OfferType offerType { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Regularity? Regularity { get; set; }

        public List<AdditionalServices>? additionalServices = new List<AdditionalServices>();
        public int? PriceOffer { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public virtual Address Address { get; set; }
        public int AddressId { get; set; }




    }

}


