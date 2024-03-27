using FluentValidation;
using Users.App.Dtos;

namespace Users.App.Validations
{
    public class LoginUserValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress();

            RuleFor(user => user.Password)
                .NotEmpty()
                .MaximumLength(16)
                .MinimumLength(8);
        }
    }
}
