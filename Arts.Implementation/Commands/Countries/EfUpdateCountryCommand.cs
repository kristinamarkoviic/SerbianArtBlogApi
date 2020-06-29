using Arts.Application.Commands;
using Arts.Application.DataTransfer;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.Countries;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Commands.Countries
{
    public class EfUpdateCountryCommand : IUpdateCountryCommand
    {
        private ArtsContext context;
        private IMapper mapper;
        private readonly UpdateCountryValidator validator;

        public EfUpdateCountryCommand(ArtsContext context, IMapper mapper, UpdateCountryValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 7;

        public string Name => "Update Country";

        public void Execute(CountryDto request)
        {


            validator.ValidateAndThrow(request);
            var findCountry = context.Countries.Find(request.Id);
            if (findCountry == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Country));
            }

            var country = context.Countries.Where(x => x.Id == request.Id).First();

            mapper.Map(request, country);
            context.SaveChanges();
        }
    }
}
