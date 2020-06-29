using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Validators.Countries
{
    public class DeleteCountryValidator: AbstractValidator<int>
    {
        public DeleteCountryValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
