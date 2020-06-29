using Arts.Application.Commands;
using Arts.Application.DataTransfer;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Commands
{
    public class EfCreateUserUseCasesCommand : ICreateUserUseCaseCommand
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        private readonly CreateUserUseCaseValidator validator;

        public EfCreateUserUseCasesCommand(ArtsContext context, IMapper mapper, CreateUserUseCaseValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        public int Id => 2;

        public string Name => "Create Users Use Case";

        public void Execute(UserUseCaseDto request)
        {
            validator.ValidateAndThrow(request);

            var useCase = mapper.Map<UserUseCases>(request);

            context.Add(useCase);
            context.SaveChanges();
        }
    }
}
