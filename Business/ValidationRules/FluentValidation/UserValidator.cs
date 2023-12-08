using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.FirstName).MaximumLength(10);
            RuleFor(u => u.LastName).MaximumLength(10);
            RuleFor(u => u.Email).MaximumLength(50);
            //RuleFor(u => u.Password).MaximumLength(60);

        }
    }
}
