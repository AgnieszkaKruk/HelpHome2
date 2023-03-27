using Domain.Models;
using System.Collections;

namespace HH2Tests.Api.IntegrationTests.DataForTests
{
    public class RegisterDtoValidatorTestsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] //meil już zajęty
            {
               new RegisterDto() { Name = "test1", Email = "test1@test1", Password = "1111111", ConfirmPassword = "1111111", PhoneNumber = "123456789", RoleId = 1 },
            };
            yield return new object[] //inne Password  i confirmPassword
            {
                new RegisterDto() { Name = "test5", Email = "test5@test5", Password = "1111112", ConfirmPassword = "1111111", PhoneNumber = "123456789", RoleId = 1 },
            };
            yield return new object[] //nieprawidłowy email
            {
                new RegisterDto() { Name = "test6", Email = "test6test6", Password = "1111111", ConfirmPassword = "1111111", PhoneNumber = "123456789", RoleId = 1 },
            };
            yield return new object[] // za krótka nazwa
           {
            new RegisterDto() { Name = "t", Email = "t@test.pl", Password = "1111111", ConfirmPassword = "1111111", PhoneNumber = "555666777", RoleId = 1 },
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
