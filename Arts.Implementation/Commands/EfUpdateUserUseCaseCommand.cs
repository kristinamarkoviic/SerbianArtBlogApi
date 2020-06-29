using Arts.Application.Commands;
using Arts.Application.DataTransfer;
using Arts.DataAccess;
using Arts.Implementation.Validators;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Commands
{
    public class EfUpdateUserUseCaseCommand : IUpdateUserUseCaseCommand
    {

        private ArtsContext context;
        private IMapper mapper;
        private readonly UpdateUserUseCaseValidator validator;

        public EfUpdateUserUseCaseCommand(ArtsContext context, IMapper mapper, UpdateUserUseCaseValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 4;

        public string Name => "Update Users Use Case";

       
        public void Execute(UserUseCaseDto request)
        {
            
        }
    }
}
