using Arts.Application.DataTransfer;
using Arts.DataAccess;
using Arts.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Validators
{
    public class RegisterUserValidator: AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(ArtsContext context)
        {
            // i ovde isto u nekom momentu dodaj regularni izraz za first name
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.CountryId).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);

            RuleFor(x => x.Email).NotEmpty()
                .Must(x=>!context.Users.Any(user => user.Email == x))
                .WithMessage("Email is already taken")
                .EmailAddress(); 

            RuleFor(x => x.PhoneNumber).Matches(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
        }
    }
}
