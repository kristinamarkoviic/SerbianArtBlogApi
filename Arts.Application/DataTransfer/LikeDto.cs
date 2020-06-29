using Arts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.DataTransfer
{
    public class LikeDto
    {
        public int UserId { get; set; }
        public int PieceOfArtId { get; set; }
        public LikeStatus Status { get; set; }
    }
}
