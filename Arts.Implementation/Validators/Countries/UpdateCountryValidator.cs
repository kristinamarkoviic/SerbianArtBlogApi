using Arts.Application.DataTransfer;
using Arts.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Validators.Countries
{
    public class UpdateCountryValidator: AbstractValidator<CountryDto>
    {
        public UpdateCountryValidator(ArtsContext context)
        {
            RuleFor(x => x.Name).NotEmpty().Must(name => !context.Countries.Any(c => c.Name == name))
                .WithMessage("Country has already exists in database.");
        }
    }
}
