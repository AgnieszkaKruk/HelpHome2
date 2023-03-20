using Data.Validators;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH2Tests
{
    public class OfferentTests
    {

        [Theory]
        [ClassData(typeof(OfferentsTestsData))]
        public void EventDateValidator_ForOverlappingEventsDates_ReturnsFalse(List<Event> events)
        {

            Event newEvent = new Event() { Start = new DateTime(2020, 1, 10, 3, 45, 6), End = new DateTime(2020, 1, 20, 2, 45, 45) };

            bool result = EventDateValidator.ValidateOverlapping(events, newEvent);

            Assert.False(result);
        }

        [Theory]
        [ClassData(typeof(OfferentsTestsData))]
        public void EventDateValidator_ForOverlappingEventsDates_ReturnsTrue(List<Event> events)
        {

            Event newEvent = new Event() { Start = new DateTime(2019, 1, 1, 1, 45, 6), End = new DateTime(2020, 12, 20, 2, 45, 45) };

            bool result = EventDateValidator.ValidateOverlapping(events, newEvent);

            Assert.True(result);
        }
    }
}
