using Arts.Application;
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
    public class EfDeletePersonalCommentCommand : IDeletePersonalCommentCommand
    {
        private readonly ArtsContext context;
        private readonly IApplicationActor actor;
        private readonly DeleteCommentValidator validator;

        public EfDeletePersonalCommentCommand(ArtsContext context, IApplicationActor actor, DeleteCommentValidator validator)
        {
            this.validator = validator;
            this.context = context;
            this.actor = actor;
        }
        public int Id => 32;

        public string Name => "EfDeletePersonalCommentCommand";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);

            var comment = context.Comments.Find(request);
            if (comment == null)
            {
                throw new EntityNotFoundException(request, typeof(Comment));
            }

            if (actor.Id != comment.UserId)
            {
                throw new UnAuthorizedAccessUserException(actor, Name);
            }


            comment.IsDeleted = true;
            comment.DeletedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}
