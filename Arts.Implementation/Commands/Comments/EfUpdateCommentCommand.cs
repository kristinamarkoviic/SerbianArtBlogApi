using Arts.Application;
using Arts.Application.Commands.Comments;
using Arts.Application.DataTransfer;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.Comments;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Commands.Comments
{
    public class EfUpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly ArtsContext context;
        private readonly IApplicationActor actor;
        private readonly IMapper mapper;
        private readonly UpdateCommentValidator validator;

        public EfUpdateCommentCommand(ArtsContext context, IApplicationActor actor, IMapper mapper, UpdateCommentValidator validator)
        {
            this.validator = validator;
            this.context = context;
            this.actor = actor;
            this.mapper = mapper;
        }
        public int Id => 30;

        public string Name => "EfUpdateCommentCommand";

        public void Execute(CommentDto request)
        {
            validator.ValidateAndThrow(request);

            var comment = context.Comments.Find(request.Id);

            if (comment == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Comment));
            }

            if (actor.Id != comment.UserId)
            {
                throw new UnAuthorizedAccessUserException(actor, Name);
            }

            var query = context.Comments.Where(x => x.Id == request.Id).FirstOrDefault();

            mapper.Map(request, query);

            context.SaveChanges();

        }
    }
}
