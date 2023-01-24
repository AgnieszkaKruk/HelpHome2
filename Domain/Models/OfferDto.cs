using HH2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OfferDto
    {

      
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? PriceOffer { get; set; }
        public virtual Address? Address { get; set; }
        public int? UserId { get; set; }

    }
}
