using Arts.Application.Commands;
using Arts.Application.DataTransfer;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.Users;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Commands.Users
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        private readonly CreateUserValidator validator;

        public EfCreateUserCommand(ArtsContext context, IMapper mapper, CreateUserValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 10;

        public string Name => "Create User";

        private IEnumerable<int> useCasesForUser = new List<int> { 1, 8, 13 };

        public void Execute(UserDto request)
        {
            validator.ValidateAndThrow(request);
            var user = mapper.Map<User>(request);

            user.Password = EasyEncryption.SHA.ComputeSHA256Hash(request.Password);
            context.Add(user);

            context.SaveChanges();

            int id = user.Id;
            foreach (var uc in useCasesForUser)
            {
                context.UserUseCases.Add(new UserUseCases
                {
                    UserId = id,
                    UseCaseId = uc
                });
            }

            context.SaveChanges();
        }
    }
}
