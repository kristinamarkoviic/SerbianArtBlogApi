using Arts.Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Validators.Comments
{
    public class UpdateCommentValidator: AbstractValidator<CommentDto>
    {
        public UpdateCommentValidator()
        {
            RuleFor(x => x.Text).NotEmpty();
        }
    }
}
