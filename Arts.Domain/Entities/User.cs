using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Domain.Entities
{
    public class User: Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }

        //referenca na drzavu
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<UserUseCases> UserUseCases { get; set; }
        public virtual ICollection<PieceOfArt> PieceOfArts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }

}
