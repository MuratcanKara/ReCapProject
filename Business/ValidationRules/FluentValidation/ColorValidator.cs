﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator: AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.Name).MaximumLength(10);
            RuleFor(c => c.BrandId).NotEmpty();
        }
    }
}
