using Arts.Application.Commands.Categories;
using Arts.Application.DataTransfer;
using Arts.Application.Exceptions;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.Categories;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Commands.Categories
{
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private ArtsContext context;
        private IMapper mapper;
        private readonly UpdateCategoryValidator validator;

        public EfUpdateCategoryCommand(ArtsContext context, IMapper mapper, UpdateCategoryValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        public int Id => 18;

        public string Name => "EfUpdateCategoryCommand";

        public void Execute(CategoryDto request)
        {
            validator.ValidateAndThrow(request);
            var findCat = context.Categories.Find(request.Id);
            if (findCat == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }

            var category = context.Categories.Where(x => x.Id == request.Id).First();

            mapper.Map(request, category);
            context.SaveChanges();
        }
    }
}
