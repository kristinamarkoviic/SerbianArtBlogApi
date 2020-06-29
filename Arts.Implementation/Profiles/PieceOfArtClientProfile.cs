using Arts.Application.DataTransfer;
using Arts.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arts.Implementation.Profiles
{
    public class PieceOfArtClientProfile: Profile
    {
        public PieceOfArtClientProfile()
        {
            CreateMap<PieceOfArt, PieceOfArtClientDto>();
            CreateMap<PieceOfArtClientDto, PieceOfArt>();

        }
    }
}
