using Arts.Application;
using Arts.Application.Commands.Likes;
using Arts.Application.DataTransfer;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Commands.Likes
{
    public class EfLikePostCommand : ILikePostCommand
    {

        private readonly ArtsContext context;
        private readonly IMapper mapper;
        private readonly IApplicationActor actor;
        private readonly LikeValidator validator;

        public EfLikePostCommand(ArtsContext context, IMapper mapper, LikeValidator validator, IApplicationActor actor)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
            this.actor = actor;
        }

        public int Id => 33;

        public string Name => "EfLikePostCommand";

        public void Execute(LikeDto request)
        {
            validator.ValidateAndThrow(request);
            var findLike = context.Likes.Where(x => x.PieceOfArtId == request.PieceOfArtId && x.UserId == request.UserId).FirstOrDefault();

            if (findLike == null)
            {
                var like = mapper.Map<Like>(request);
                context.Likes.Add(like);
                context.SaveChanges();
            }
            else
            {
                findLike.Status = request.Status;
                context.SaveChanges();
            }

        }
    }
}
