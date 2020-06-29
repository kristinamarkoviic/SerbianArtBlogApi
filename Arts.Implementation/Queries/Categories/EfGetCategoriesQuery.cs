using Arts.Application.DataTransfer;
using Arts.Application.Queries;
using Arts.Application.Queries.Categories;
using Arts.Application.Searches;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Queries.Categories
{
    public class EfGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        public EfGetCategoriesQuery(ArtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 20;

        public string Name => "EfGetCategoriesQuery";

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            var query = context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<CategoryDto, Category>(search, mapper);
        }
    }
}
