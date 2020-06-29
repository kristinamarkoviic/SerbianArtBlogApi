using Arts.Application.DataTransfer;
using Arts.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Profiles
{
    public class SingleCategoryProfile: Profile
    {
        public SingleCategoryProfile()
        {
            CreateMap<Category, SingleCategoryDto>()
                .ForMember(
                dto => dto.PieceOfArts,
                ent => ent.MapFrom(x =>
                x.PieceOfArts.ToList()
                ));

            CreateMap<SingleCategoryDto, Category>()
            .ForMember(
            dto => dto.PieceOfArts,
            ent => ent.MapFrom(x =>
            x.PieceOfArts.Select(y => y.Id).ToList()
            ));


        }
    }
}
