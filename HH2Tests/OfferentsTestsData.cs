using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH2Tests
{
    public class OfferentsTestsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {

                new List<Event>()
                {
                    new Event() { Start = new DateTime(2020, 1, 1, 7, 47, 0), End = new DateTime(2020, 1, 15, 6, 45, 3) },
                    new Event() { Start = new DateTime(2020, 2, 1, 5, 12, 4), End = new DateTime(2020, 2, 15, 8, 32, 4) }

                }
            };
            yield return new object[]
            {

                new List<Event>()
                {
                   new Event() { Start = new DateTime(2020, 1, 1, 7, 47, 0), End = new DateTime(2020, 1, 15, 6, 45, 3) },

                }
            };
            yield return new object[]
            {

                new List<Event>()
                {
                    new Event() { Start = new DateTime(2020, 1, 8, 7, 47, 0), End = new DateTime(2020, 1, 25, 6, 45, 3) },
              
                }
            };
            yield return new object[]
            {

                new List<Event>()
                {
                    new Event() { Start = new DateTime(2020, 1, 20, 23, 12, 4), End = new DateTime(2020, 1, 21, 8, 32, 4) }

                }
            };
        }

       IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}

