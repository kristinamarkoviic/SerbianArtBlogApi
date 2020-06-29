using Arts.Application;
using Arts.Application.DataTransfer;
using Arts.Application.Queries;
using Arts.Application.Queries.Users;
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

namespace Arts.Implementation.Queries.Users
{
    public class EfGetUsersClientQuery : IGetUsersClientQuery
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        public EfGetUsersClientQuery(ArtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 14;

        public string Name => "EfGetUsersClientQuery";

       
        PagedResponse<UserClientDto> IQuery<UserSearch, PagedResponse<UserClientDto>>.Execute(UserSearch search)
        {
            var query = context.Users.Include(u => u.Country).AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.LastName) || !string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Email) || !string.IsNullOrWhiteSpace(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }


            return query.Paged<UserClientDto, User>(search, mapper);
        }
    }
}
