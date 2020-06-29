using Arts.Application.DataTransfer;
using Arts.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Profiles
{
    public class UserUseCaseLogProfile: Profile
    {
        public UserUseCaseLogProfile()
        {
            CreateMap<Domain.Entities.UseCaseLog, UseCaseLogDto>();
            CreateMap<UseCaseLogDto, Domain.Entities.UseCaseLog>();
        }
    }
}
