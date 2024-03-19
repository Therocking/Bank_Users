using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .MaximumLength(125)
                .MinimumLength(6);
        }
    }
}
