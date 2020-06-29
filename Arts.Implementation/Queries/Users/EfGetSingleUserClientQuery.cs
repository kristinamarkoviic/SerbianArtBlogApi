using Arts.Application.DataTransfer;
using Arts.Application.Exceptions;
using Arts.Application.Queries.Users;
using Arts.DataAccess;
using Arts.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Queries.Users
{
    public class EfGetSingleUserClientQuery : IGetOneUserClientQuery
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        public EfGetSingleUserClientQuery(ArtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 16;

        public string Name => "EfGetSingleUserClientQuery";

        public SingleUserClientDto Execute(int search)
        {
            var u = context.Users.Find(search);

            if (u == null)
            {
                throw new EntityNotFoundException(search, typeof(User));
            }

            var query = context.Users.Include(u => u.Country).Include(u => u.PieceOfArts).Where(u => u.Id == search).First();

            var user = mapper.Map<SingleUserClientDto>(query);

            return user;
        }
    }
}
