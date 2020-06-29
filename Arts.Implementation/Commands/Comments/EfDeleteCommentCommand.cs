using Arts.Application.Commands.Comments;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.Comments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Commands.Comments
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly ArtsContext context;
        private readonly DeleteCommentValidator validator;

        public EfDeleteCommentCommand(ArtsContext context, DeleteCommentValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public int Id => 31;

        public string Name => "EfDeleteCommentCommand";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);

            var comment = context.Comments.Find(request);
            if (comment == null)
            {
                throw new EntityNotFoundException(request, typeof(Comment));
            }


            comment.IsDeleted = true;
            comment.DeletedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}
