using Domain.Utils;
using HH2.Entities;
using HH2.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OfferDto
    {
    //    [JsonConverter(typeof(JsonStringEnumConverter))]
    //    [Required]
    //    public OfferType offerType { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? PriceOffer { get; set; }

        //[JsonConverter(typeof(JsonStringEnumConverter))]
        //public Regularity? Regularity { get; set; }
        //[JsonConverter(typeof(JsonStringEnumConverter))]
        //public List<AdditionalServices>? additionalServices { get; set;}

        //[JsonConverter(typeof(JsonStringEnumConverter))]
        //public List<Room>? Rooms { get; set; }
        public virtual Address? Address { get; set; }
        public int? UserId { get; set; }

    }
}
