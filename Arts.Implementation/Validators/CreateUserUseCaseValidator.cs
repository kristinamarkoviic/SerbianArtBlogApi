using Arts.Application.DataTransfer;
using Arts.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Validators
{
    public class CreateUserUseCaseValidator: AbstractValidator<UserUseCaseDto>
    {
        public CreateUserUseCaseValidator(ArtsContext context)
        {
            RuleFor(x => x.UseCaseId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty()
                .Must(x => context.Users.Any(user => user.Id == x))
                .WithMessage("Users Id has to be in database");

        }
    }
}
