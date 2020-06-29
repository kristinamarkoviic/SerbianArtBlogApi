using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Domain.Entities
{
    public class Comment: Entity
    {
        public string Text { get; set; }
        public int PieceOfArtId { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
        public virtual PieceOfArt PieceOfArt { get; set; }
        public virtual User User { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual ICollection<Comment> Children { get; set; }
    }
}
