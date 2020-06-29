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
    public class EfCreateCountryCommand : ICreateCountryCommand
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        private readonly CreateCountryValidator validator;

        public EfCreateCountryCommand(ArtsContext context, IMapper mapper, CreateCountryValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        
        public int Id => 5;

        public string Name => "Create new country using EF.";

        public void Execute(CountryDto request)
        {
            validator.ValidateAndThrow(request);

            var country = mapper.Map<Country>(request);
            context.Countries.Add(country);
            context.SaveChanges();
            
        }
    }
}
