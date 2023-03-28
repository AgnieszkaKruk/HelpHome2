using Domain.Utils;
using HH2.Entities;
using HH2.Utils;
//using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Domain.Models
{
    public class OfferDto
    {
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        [Required]
        public OfferType offertype { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? PriceOffer { get; set; }

        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public Regularity? regularity { get; set; }
       
        public virtual Address? Address { get; set; }
        public int? UserId { get; set; }

    }
}
