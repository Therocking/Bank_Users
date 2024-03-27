using FluentValidation;
using Users.App.Dtos;
using Users.App.Services.Helpers;

namespace Users.App.Validations
{
    public class RegisterUserValidator: AbstractValidator<RegisterUserDto>
    {
        private readonly ValidateEmailUnique _validation;
        public RegisterUserValidator(ValidateEmailUnique validateEmailUnique)
        {
            _validation = validateEmailUnique;

            RuleFor(user => user.Email)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress()
                .Must(BeUniqueEmail)
                .WithMessage("El correo electrónico ya existe.");

            RuleFor(user => user.Password)
                .NotEmpty()
                .MaximumLength(16)
                .MinimumLength(8);

            RuleFor(user => user.Name)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(3);
        }

        private bool BeUniqueEmail(string email)
        {
            return _validation.IsEmailUnique(email);
        }
    }
}
