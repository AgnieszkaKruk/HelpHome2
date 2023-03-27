using Domain.Models;
using System.Collections;

namespace HH2Tests.Api.IntegrationTests.DataForTests
{
    public class LoginDtoValidatorTestsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] //meil już zajęty
            {
               new LoginDto() { Email = "test1test1", Password = "1111111"},
            };
            yield return new object[] //inne Password  i confirmPassword
            {
                new LoginDto() { Email = "", Password = "1111112"},
            };
            yield return new object[] //nieprawidłowy email
            {
                new LoginDto() {Email = "test6test6", Password = ""},
            };
           
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
