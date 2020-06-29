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
    public class EfGetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        public EfGetUseCaseLogsQuery(ArtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 9;

        public string Name => "Search Audit Log";

        public PagedResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var query = context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor))
            {
                
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));

            }
            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if(!string.IsNullOrEmpty(search.DateStart) || !string.IsNullOrWhiteSpace(search.DateStart) ||
               !string.IsNullOrEmpty(search.DateEnd) || !string.IsNullOrWhiteSpace(search.DateEnd) ) {

                DateTime startDate = Convert.ToDateTime(search.DateStart);
                DateTime endDate = Convert.ToDateTime(search.DateEnd);

                query = query.Where(x => x.Date >= startDate && x.Date <= endDate);
            }

            return query.Paged<UseCaseLogDto, Domain.Entities.UseCaseLog>(search, mapper);
            //var skipCount = search.PerPage * (search.Page - 1);

            ////Page == 1 
            //var reponse = new PagedResponse<UseCaseLogDto>
            //{
            //    CurrentPage = search.Page,
            //    ItemsPerPage = search.PerPage,
            //    TotalCount = query.Count(),
            //    Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UseCaseLogDto
            //    {
            //        //maper dodaj ovde
            //        Id = x.Id,
            //        Actor = x.Actor,
            //        UseCaseName = x.UseCaseName,
            //        Data = x.Data,
            //        Date = x.Date
            //    }).ToList()
            //};

            //return reponse;
        }
    }
}
