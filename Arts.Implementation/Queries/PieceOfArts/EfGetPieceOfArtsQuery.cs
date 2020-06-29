using Arts.Application.DataTransfer;
using Arts.Application.Queries;
using Arts.Application.Queries.Categories;
using Arts.Application.Queries.PieceOfArts;
using Arts.Application.Searches;
using Arts.DataAccess;
using Arts.Domain.Entities;
using Arts.Implementation.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Queries.PieceOfArts
{
    public class EfGetPieceOfArtsQuery : IGetPieceOfArtQuery
    {

        private readonly ArtsContext context;
        private readonly IMapper mapper;
        public EfGetPieceOfArtsQuery(ArtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 24;

        public string Name => "EfGetPieceOfArtsQuery";

        public PagedResponse<PieceOfArtClientDto> Execute(PieceOfArtSearch search)
        {
            var query = context.PieceOfArts.Include(c => c.Category).Include(u => u.User).ThenInclude(cc => cc.Country).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<PieceOfArtClientDto, PieceOfArt>(search, mapper);
        }
    }
}
