using Arts.Application.Commands;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Commands.Users
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {

        private readonly ArtsContext context;

        public EfDeleteUserCommand(ArtsContext context)
        {
            this.context = context;
        }
        public int Id => 11;

        public string Name => "Delete User";

        public void Execute(int request)
        {
            var user = context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(Domain.Entities.User));
            }

            user.DeletedAt = DateTime.Now;
            user.IsDeleted = true;

            context.SaveChanges();
        }
    }
}
