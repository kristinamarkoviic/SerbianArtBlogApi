using Arts.Application.Commands.Categories;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Commands.Categories
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {

        private readonly ArtsContext context;
        private readonly DeleteCategoryValidator validator;

        public EfDeleteCategoryCommand(ArtsContext context, DeleteCategoryValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public int Id => 19;

        public string Name => "EfDeleteCategoryCommand";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);
            var findCat = context.Categories.Find(request);

            if(findCat == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            findCat.IsDeleted = true;
            findCat.DeletedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}
