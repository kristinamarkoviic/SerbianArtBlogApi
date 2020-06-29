using Arts.Application.DataTransfer;
using Arts.Application.Exceptions;
using Arts.Application.Queries.Categories;
using Arts.DataAccess;
using Arts.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Queries.Categories
{
    public class EfGetOneCategoryQuery : IGetOneCategoryQuery
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;

        public EfGetOneCategoryQuery(ArtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 28;

        public string Name => "EfGetOneCategoryQuery";

        public SingleCategoryDto Execute(int search)
        {
            var findCat = context.Categories.Find(search);

            if (findCat == null)
            {
                throw new EntityNotFoundException(search, typeof(Category));
            }

            var query = context.Categories.Include(u => u.PieceOfArts).Where(u => u.Id == search).First();

            var category = mapper.Map<SingleCategoryDto>(query);

            return category;
        }
    }
}
