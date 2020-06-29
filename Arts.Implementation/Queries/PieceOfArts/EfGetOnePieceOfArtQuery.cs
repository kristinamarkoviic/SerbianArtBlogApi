using Arts.Application;
using Arts.Application.DataTransfer;
using Arts.Application.Exceptions;
using Arts.Application.Queries;
using Arts.Application.Queries.PieceOfArts;
using Arts.Application.Searches;
using Arts.DataAccess;
using Arts.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Queries.PieceOfArts
{
    public class EfGetOnePieceOfArtQuery : IGetOnePieceOfArtQuery
    {

        private readonly ArtsContext context;
        private readonly IMapper mapper;
        public EfGetOnePieceOfArtQuery(ArtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 25;

        public string Name => "EfGetOnePieceOfArtQuery";

        public ICollection<SingleCommentDto> parentComments { get; set; } = new List<SingleCommentDto>();

        PieceOfArtClientDto IQuery<int, PieceOfArtClientDto>.Execute(int search)
        {
            var post = context.PieceOfArts.Find(search);

            if (post == null)
            {
                throw new EntityNotFoundException(search, typeof(PieceOfArt));
            }

            var query = context.PieceOfArts.Include(com => com.Comments)
                .Include(l => l.Likes)
                .Include(c => c.Category)
                .Include(u => u.User)
                .ThenInclude(cc => cc.Country)
                .Where(p => p.Id == search)
                .First();



            var result = mapper.Map<PieceOfArtClientDto>(query);

            foreach(var res in result.Comments)
            {
                if( res.ParentId == 0)
                {
                    parentComments.Add(res);
                }
            }
            result.Comments = parentComments;
            return result;
        }
    }
}
