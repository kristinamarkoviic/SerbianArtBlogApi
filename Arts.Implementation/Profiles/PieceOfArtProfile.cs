using Arts.Application.DataTransfer;
using Arts.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Implementation.Profiles
{
    public class PieceOfArtProfile: Profile
    {
        public PieceOfArtProfile()
        {
            CreateMap<PieceOfArt, PieceOfArtDto>();

            CreateMap<PieceOfArtDto, PieceOfArt>().ForMember(x => x.Picture, opt => opt.Ignore())
;
        }
    }
}
