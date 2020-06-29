using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Domain.Entities
{
    public class Category: Entity
    {
        public string Name { get; set; }
        public  virtual ICollection<PieceOfArt> PieceOfArts { get; set; }
    }
}
