using Arts.Application.DataTransfer;
using Arts.Application.Queries;
using Arts.Application.Searches;
using Arts.DataAccess;
using Arts.Implementation.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Queries
{
    public class EfGetCountriesQuery : IGetCountriesQuery
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        public EfGetCountriesQuery(ArtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Countries Search";

        public PagedResponse<CountryDto> Execute(CountrySearch search)
        {
            var query = context.Countries.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<CountryDto, Domain.Entities.Country>(search, mapper);
            

        }
    }
}
