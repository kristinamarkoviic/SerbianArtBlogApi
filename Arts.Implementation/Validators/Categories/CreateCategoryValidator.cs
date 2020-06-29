using Arts.Application.DataTransfer;
using Arts.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Validators.Categories
{
    public class CreateCategoryValidator: AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator(ArtsContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .Must(c => !context.Categories.Any(ca => ca.Name == c))
                .WithMessage($"Category name must be unique");
        }
        
    }
}
