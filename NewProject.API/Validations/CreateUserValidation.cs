using FluentValidation;
using VendorView.Application;
using VendorView.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorView.API.Validations
{
    public class CreateUserValidation:AbstractValidator<CreateUserInput>
    {
        public CreateUserValidation()
        {
           RuleFor(u=>u.PhoneNumber).NotNull().NotEmpty().WithMessage(Constanties.PhoneNumber_REQUIRED);
           RuleFor(u=>u.FullName).NotNull().NotEmpty().WithMessage(Constanties.FULLNAME_REQUIRED);
           RuleFor(u=>u.PasswordHash).NotNull().NotEmpty().WithMessage(Constanties.PASSWORD_REQUIRED);
           RuleFor(u=>u.RoleName).NotNull().NotEmpty().WithMessage(Constanties.ROLE_REQUIRED);
        }
    }
}
