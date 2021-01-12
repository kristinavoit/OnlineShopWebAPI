using FluentValidation;
using OnlineShopWebAPI.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebAPI.API.Validators
{
    public class SaveProductResourceValidator : AbstractValidator<SaveProductResource>
    {
        public SaveProductResourceValidator() {
            RuleFor(a => a.Title)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
