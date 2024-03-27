using FluentValidation;
using Users.App.Dtos;

namespace Users.App.Validations
{
    public class RegisterUserValidator: AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress();

            RuleFor(user => user.Password)
                .NotEmpty()
                .MaximumLength(16)
                .MinimumLength(8);

            RuleFor(user => user.Name)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(3);
        }
    }
}
