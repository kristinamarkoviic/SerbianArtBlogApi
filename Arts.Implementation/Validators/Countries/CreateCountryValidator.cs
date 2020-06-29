using Arts.Application.DataTransfer;
using Arts.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Validators
{
    public class CreateCountryValidator: AbstractValidator<CountryDto>
    {

        public CreateCountryValidator(ArtsContext context)
        {
            RuleFor(x => x.Name).NotEmpty().Must(name => !context.Countries.Any(c => c.Name == name))
                .WithMessage("Country has already exists in database.");
        }
    }
}
