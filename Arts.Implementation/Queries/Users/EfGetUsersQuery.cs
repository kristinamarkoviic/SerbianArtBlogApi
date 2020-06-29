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
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        public EfGetUsersQuery(ArtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 13;

        public string Name => "EfGetUsersQuery";

        PagedResponse<UserDto> IQuery<UserSearch, PagedResponse<UserDto>>.Execute(UserSearch search)
        {
            var query = context.Users.Include(x => x.UserUseCases).Include(u => u.Country).AsQueryable(); //spajam usera sa usecases

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


            return query.Paged<UserDto, User>(search, mapper);
        }
    }
}
