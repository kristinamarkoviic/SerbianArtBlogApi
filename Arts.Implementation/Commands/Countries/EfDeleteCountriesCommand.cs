using Arts.Application.Commands;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.Countries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Commands
{
    public class EfDeleteCountriesCommand : IDeleteCountryCommand
    {
        private readonly ArtsContext context;
        private readonly DeleteCountryValidator validator;

        public EfDeleteCountriesCommand(ArtsContext context, DeleteCountryValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public int Id => 6;

        public string Name => "Delete Country using Ef.";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);
            var country = context.Countries.Find(request);

            if(country == null)
            {
                throw new EntityNotFoundException(request, typeof(Country));
            }

            country.DeletedAt = DateTime.Now;
            country.IsDeleted = true;

            context.SaveChanges();
            

        }
    }
}
