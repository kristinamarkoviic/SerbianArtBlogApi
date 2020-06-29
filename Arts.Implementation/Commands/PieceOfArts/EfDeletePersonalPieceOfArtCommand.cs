using Arts.Application;
using Arts.Application.Commands.PieceOfArts;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using Arts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Commands.PieceOfArts
{
    public class EfDeletePersonalPieceOfArtCommand : IDeletePersonalPieceOfArtCommand
    {
        private readonly ArtsContext context;
        private readonly IApplicationActor actor;

        public EfDeletePersonalPieceOfArtCommand(ArtsContext context, IApplicationActor actor)
        {
            this.actor = actor;
            this.context = context;
        }
        public int Id => 27;

        public string Name => "EfDeletePersonalPieceOfArtCommand";

        public void Execute(int request)
        {
            var findPost = context.PieceOfArts.Find(request);

            if (findPost == null)
            {
                throw new EntityNotFoundException(request, typeof(PieceOfArt));
            }

            if(actor.Id != findPost.UserId)
            {
                throw new UnAuthorizedAccessUserException(actor, Name);
            }

            findPost.IsDeleted = true;
            findPost.DeletedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}
