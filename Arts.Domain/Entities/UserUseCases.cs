using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Domain.Entities
{
    public class UserUseCases
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int UseCaseId { get; set; }

        public virtual User User { get; set; }
    }
}
