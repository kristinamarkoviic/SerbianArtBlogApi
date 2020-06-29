using Arts.Application.Commands.Categories;
using Arts.Application.DataTransfer;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Validators.Categories;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Commands.Categories
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        private readonly CreateCategoryValidator validator;

        public EfCreateCategoryCommand(ArtsContext context, IMapper mapper, CreateCategoryValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 17;

        public string Name => "EfCreateCategoryCommand";

        public void Execute(CategoryDto request)
        {
            validator.ValidateAndThrow(request);

            var category = mapper.Map<Category>(request);
            context.Categories.Add(category);
            context.SaveChanges();


        }
    }
}
