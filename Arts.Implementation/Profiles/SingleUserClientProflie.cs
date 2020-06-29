using Arts.Application.DataTransfer;
using Arts.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Profiles
{
    public class SingleUserClientProflie: Profile
    {
        public SingleUserClientProflie()
        {
            CreateMap<User, SingleUserClientDto>();
            CreateMap<SingleUserClientDto, User>();
        }
    }
}
