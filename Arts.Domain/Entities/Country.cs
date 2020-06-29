using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Domain.Entities
{
    public class Country: Entity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
