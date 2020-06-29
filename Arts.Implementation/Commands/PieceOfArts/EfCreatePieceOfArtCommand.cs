using Arts.Application.Commands.PieceOfArts;
using Arts.Application.DataTransfer;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.PieceOfArts;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Arts.Implementation.Commands.PieceOfArts
{
    public class EfCreatePieceOfArtCommand : ICreatePieceOfArtCommand
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        private readonly CreatePieceOfArtValidator validator;

        public EfCreatePieceOfArtCommand(ArtsContext context, IMapper mapper, CreatePieceOfArtValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        public int Id => 21;

        public string Name => "EfCreatePieceOfArtCommand";

        public void Execute(PieceOfArtDto request)
        {
            validator.ValidateAndThrow(request);


            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Picture.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Picture.CopyTo(fileStream);
            }

            

            var post = mapper.Map<PieceOfArt>(request);
            post.Picture = newFileName;
            context.PieceOfArts.Add(post);
            context.SaveChanges();
        }
    }
}
