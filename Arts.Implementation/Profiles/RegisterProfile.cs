using Arts.Application.DataTransfer;
using Arts.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arts.Implementation.Profiles
{
    public class RegisterProfile: Profile
    {
        public RegisterProfile()
        {
            CreateMap<User, RegisterUserDto>();
            CreateMap<RegisterUserDto, User>();
        }
    }
}
