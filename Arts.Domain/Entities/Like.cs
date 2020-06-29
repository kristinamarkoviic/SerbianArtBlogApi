using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Domain.Entities
{
    public class Like: Entity
    {
        public int UserId { get; set; }
        public int PieceOfArtId { get; set; }
        public LikeStatus Status { get; set; }
        public virtual User User { get; set; }
        public virtual PieceOfArt PieceOfArt { get; set; }

    }

    public enum LikeStatus
    {
        Liked,
        Disliked,
        Null
    }


}
