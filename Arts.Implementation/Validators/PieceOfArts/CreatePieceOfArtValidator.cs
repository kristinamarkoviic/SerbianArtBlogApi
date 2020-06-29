using Arts.Application.DataTransfer;
using Arts.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Validators.PieceOfArts
{
    public  class CreatePieceOfArtValidator: AbstractValidator<PieceOfArtDto>
    {
        public CreatePieceOfArtValidator(ArtsContext context)
        {
            RuleFor(x => x.Name).NotEmpty().Must(x => !context.PieceOfArts.Any(piece => piece.Name == x))
                    .WithMessage("Name of piece of art has to be unique. Name has been alreafy taken.").MinimumLength(3);

            RuleFor(x => x.Description).MinimumLength(15);

            RuleFor(x => x.Picture)
               .NotEmpty();


            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .Must(catId => context.Categories.Any(p => p.Id == catId))
                .WithMessage("Category has to be valid.");

            RuleFor(x => x.Year).NotEmpty().InclusiveBetween(1000, 2020);

            RuleFor(x => x.Price).NotNull();


        }
    }
}
