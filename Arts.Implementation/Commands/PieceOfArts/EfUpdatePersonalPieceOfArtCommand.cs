using Arts.Application;
using Arts.Application.Commands.PieceOfArts;
using Arts.Application.DataTransfer;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.PieceOfArts;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Commands.PieceOfArts
{
    public class EfUpdatePersonalPieceOfArtCommand : IUpdatePersonalPieceOfArtCommand
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        private readonly CreatePieceOfArtValidator validator;
        private readonly IApplicationActor actor;

        public EfUpdatePersonalPieceOfArtCommand(ArtsContext context, IMapper mapper, CreatePieceOfArtValidator validator, IApplicationActor actor)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
            this.actor = actor;
        }
        public int Id => 26;

        public string Name => "EfUpdatePersonalPieceOfArtCommand";

        public void Execute(PieceOfArtDto request)
        {
            validator.ValidateAndThrow(request);

            var findPost = context.PieceOfArts.Find(request.Id);
            if(findPost == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(PieceOfArt));
            }

            if(actor.Id != findPost.UserId)
            {
                throw new UnAuthorizedAccessUserException(actor, Name);
            }

            var post = context.PieceOfArts.Where(x => x.Id == request.Id).First();

            var newFileName = "";

            if (request.Picture != null)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(request.Picture.FileName);

                newFileName = guid + extension;

                var path = Path.Combine("wwwroot", "images", newFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    request.Picture.CopyTo(fileStream);
                }
            }
            else
            {
                newFileName = post.Picture;
            }

            mapper.Map(request, post);
            post.Picture = newFileName;
            context.SaveChanges();

        }
    }
}
