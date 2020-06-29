using Arts.Application.DataTransfer;
using Arts.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Validators.Users
{
    public class UpdateUserValidator: AbstractValidator<UserDto>
    {
        public UpdateUserValidator(ArtsContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.CountryId).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Email).NotEmpty()
                    .Must(x => !context.Users.Any(user => user.Email == x))
                    .WithMessage("Email is already taken")
                    .EmailAddress();

            RuleFor(x => x.PhoneNumber).Matches(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");

            RuleFor(x => x.useCasesForUser)
                .NotEmpty();
        }
    }
}
