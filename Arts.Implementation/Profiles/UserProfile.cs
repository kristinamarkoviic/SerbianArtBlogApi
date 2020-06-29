using Arts.Application.DataTransfer;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Entities.User, UserDto>()
                .ForMember(
                dto => dto.useCasesForUser,
                us => us.MapFrom(x =>
               x.UserUseCases.Select(y => y.UseCaseId).ToList()));

            CreateMap<UserDto, Domain.Entities.User>();
        }
    }
}
