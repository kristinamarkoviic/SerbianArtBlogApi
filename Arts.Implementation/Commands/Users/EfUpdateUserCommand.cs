using Arts.Application.Commands;
using Arts.Application.DataTransfer;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.Users;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Commands.Users
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        private readonly UpdateUserValidator validator;

        public EfUpdateUserCommand(ArtsContext context, IMapper mapper, UpdateUserValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 12;

        public string Name => "Update User";

        

        public void Execute(UserDto request)
        {
            validator.ValidateAndThrow(request);

            var findUser = context.Users.Find(request.Id);

            if (findUser == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(User));
            }

            var user = context.Users.Include(x => x.UserUseCases).Where(x => x.Id == request.Id).First();

            mapper.Map(request, user);


            foreach (var uc in user.UserUseCases)
            {
                context.Remove(uc);
            }

            foreach(var ucNew in request.useCasesForUser)
            {
                context.UserUseCases.Add(new UserUseCases
                {
                    UseCaseId = ucNew,
                    UserId = request.Id
                }) ;
            }


            user.Password = EasyEncryption.SHA.ComputeSHA256Hash(request.Password);

            context.SaveChanges();

        }
    }
}
