
using Domain.Models;
using FluentValidation;
using HH2;

namespace Data.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator(HHDbContext hhDbContext)
        {
            RuleFor(e => e.Email).NotEmpty().EmailAddress();
            RuleFor(e => e.Password).NotEmpty();

        }
    }
}


