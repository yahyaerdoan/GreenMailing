using FluentValidation;
using GreenMailing.DataTransferObjectLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.BusinessLayer.Concrete.ValidationRules.UserValidationRules
{
	public class LogInUserValidator : AbstractValidator<LogInUserDto>
	{
        public LogInUserValidator()
        {
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email can not be empty!");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty!");
		}
    }
}