using Arts.Application.DataTransfer;
using Arts.DataAccess;
using Arts.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Validators.Comments
{
    public class CreateCommentValidator: AbstractValidator<CommentDto>
    {
        public CreateCommentValidator(ArtsContext context)
        {
            RuleFor(x => x.Text).NotEmpty();

            RuleFor(x => x.PieceOfArtId)
                .NotEmpty()
                .Must(pieceId => context.PieceOfArts.Any(p => p.Id == pieceId))
                .WithMessage("Piece of art have to exists in database.");


            RuleFor(x => x.ParentId)
                .Must(commID => context.Comments.Any(c => c.Id == commID))
                .When(request => request.ParentId != null)
                .WithMessage("Parent comment have to exists in database.");
        }
    }
}
