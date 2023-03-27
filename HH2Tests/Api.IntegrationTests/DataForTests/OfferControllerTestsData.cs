using Domain.Utils;
using HH2.Entities;
using System.Collections;
using System.Xml.Linq;

namespace HH2Tests.Api.IntegrationTests.DataForTests
{
    public class OfferControllerTestsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
            new Offer(){ Id = 1, Name = "Sprzątanie", PriceOffer = 100, offerType = Domain.Utils.OfferType.Sprzątanie },
            };
            yield return new object[]
            {
            new Offer(){ Id = 2, Name = "Mycie okien", PriceOffer = 300, offerType = Domain.Utils.OfferType.MycieOkien },
            };
            yield return new object[]
            {
            new Offer(){ Id = 3, Name = "Pranie dywanów", PriceOffer = 1200, offerType = Domain.Utils.OfferType.PranieDywanów },
            };
            yield return new object[]
            {
            new Offer(){ Id = 4, Name = "Sprzątanie", PriceOffer = 70, offerType = Domain.Utils.OfferType.Sprzątanie },
            };
          
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
