using Domain.Entities;
using HH2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<OfferDto> OfferDtos { get; set; }
        public List<Event> Events { get; set; }
    }
}






