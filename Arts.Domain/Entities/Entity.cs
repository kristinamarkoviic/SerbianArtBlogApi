using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } //cim se uradi insert da znamo vreme
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; } //false difoltno. kad promenimo bice true
        public DateTime? DeletedAt { get; set; }
    }
}
