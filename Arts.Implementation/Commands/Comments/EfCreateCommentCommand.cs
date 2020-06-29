using Arts.Application;
using Arts.Application.Commands.Comments;
using Arts.Application.DataTransfer;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.Comments;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Commands.Comments
{
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private readonly ArtsContext context;
        private readonly IApplicationActor actor;
        private readonly IMapper mapper;
        private readonly CreateCommentValidator validator;

        public EfCreateCommentCommand(ArtsContext context, IApplicationActor actor, IMapper mapper, CreateCommentValidator validator)
        {
            this.validator = validator;
            this.context = context;
            this.actor = actor;
            this.mapper = mapper;
        }
        public int Id => 29;

        public string Name => "EfCreateCommentCommand";

        public void Execute(CommentDto request)
        {
            validator.ValidateAndThrow(request);
            request.UserId = actor.Id;
            var comment = mapper.Map<Comment>(request);

            context.Add(comment);
            context.SaveChanges();
        }
    }
}
