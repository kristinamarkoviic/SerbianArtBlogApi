using Arts.Application.Commands;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using Arts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Commands
{
    public class EfDeleteUserUseCaseCommand : IDeleteUserUseCaseCommand
    {

        private readonly ArtsContext context;

        public EfDeleteUserUseCaseCommand(ArtsContext context)
        {
            this.context = context;
        }
        public int Id => 3;

        public string Name => "Delete Users Use Case";

        public void Execute(int request)
        {
            var useCase = context.UserUseCases.Find(request);

            if (useCase == null)
            {
                throw new EntityNotFoundException(request, typeof(UserUseCases));
            }

            context.UserUseCases.Remove(useCase);

            context.SaveChanges();
        }
    }
}
