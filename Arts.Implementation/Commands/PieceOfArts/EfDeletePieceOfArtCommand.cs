using Arts.Application.Commands.PieceOfArts;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.PieceOfArts;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Arts.Implementation.Commands.PieceOfArts
{
    public class EfDeletePieceOfArtCommand : IDeletePieceOfArtCommand
    {
        private readonly ArtsContext context;
        private readonly DeletePieceOfArtValidator validator;

        public EfDeletePieceOfArtCommand(ArtsContext context, DeletePieceOfArtValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public int Id => 23;

        public string Name => "EfDeletePieceOfArtCommand";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);
            
            var findPost = context.PieceOfArts.Find(request);

            if (findPost == null)
            {
                throw new EntityNotFoundException(request, typeof(PieceOfArt));
            }

            findPost.IsDeleted = true;
            findPost.DeletedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}
