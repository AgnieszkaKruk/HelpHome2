using Domain.Entities;
using Domain.Utils;

namespace HH2Tests.UnitTests
{
    public class EventTests
    {
        [Theory]
        [InlineData("Orange", EventStatus.Booked)]
        [InlineData("Red", EventStatus.Rejected)]
        [InlineData("Blue", EventStatus.Accepted)]
        public void SetColor_ForGivenStatus_SetCorrectColorProperty(string color, EventStatus status)
        {
            Event myEvent = new Event();
            myEvent.Status = status;

            myEvent.SetColor();
            string resultColor = myEvent.Color;


            Assert.Equal(color, resultColor);
        }
    }
}