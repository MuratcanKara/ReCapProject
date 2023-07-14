using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.CompanyName).MaximumLength(40);
            RuleFor(c => c.ContactName).MaximumLength(30);
            RuleFor(c => c.ContactTitle).MaximumLength(30);
            RuleFor(c => c.Address).MaximumLength(60);
            RuleFor(c => c.City).MaximumLength(15);
            RuleFor(c => c.Region).MaximumLength(15);
            RuleFor(c => c.ContactTitle).MaximumLength(30);
            RuleFor(c => c.PostalCode).MaximumLength(10);
            RuleFor(c => c.Country).MaximumLength(15);
            RuleFor(c => c.Phone).MaximumLength(24);
            RuleFor(c => c.Fax).MaximumLength(24);
        }
    }
}
