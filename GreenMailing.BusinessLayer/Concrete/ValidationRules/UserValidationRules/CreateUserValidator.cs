using FluentValidation;
using GreenMailing.DataTransferObjectLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.BusinessLayer.Concrete.ValidationRules.UserValidationRules
{
	public class CreateUserValidator : AbstractValidator<CreateUserDto>
	{
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name can not be empty!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name can not be empty!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name can not be empty!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can not be empty!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm password can not be empty!");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Passwords do not match!");
        }
    }
}