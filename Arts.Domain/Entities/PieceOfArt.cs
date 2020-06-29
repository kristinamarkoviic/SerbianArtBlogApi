using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Domain.Entities
{
    public class PieceOfArt: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

    }
}
