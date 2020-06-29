using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Validators.PieceOfArts
{
    public class DeletePieceOfArtValidator: AbstractValidator<int>
    {
        public DeletePieceOfArtValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
