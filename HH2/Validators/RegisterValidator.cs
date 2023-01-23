using Domain.Models;
using FluentValidation;
using HH2;

namespace Data.Validators
{

    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator(HHDbContext hhcontext)
        {

            RuleFor(x => x.Name).NotEmpty().MaximumLength(25);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = hhcontext.Users.Any(x => x.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "This email is taken");
                    }
                });
        }
    }


}
