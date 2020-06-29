using Arts.Application.DataTransfer;
using Arts.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Profiles
{
    public class SingleUserProfile: Profile
    {
        public SingleUserProfile()
        {
            CreateMap<User, SingleUserDto>()
                .ForMember(
                dto => dto.useCasesForUser,
                ent => ent.MapFrom(x =>
                x.UserUseCases.Select(y => y.UseCaseId).ToList()
                ));
            CreateMap<SingleUserDto, User>();
        }
        
    }
}
