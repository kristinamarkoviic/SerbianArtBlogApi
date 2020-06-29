using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Domain.Entities
{
    public class UseCaseLog
    {
        //ovo je za cuvanje logova tj aktivnosti korisnika sistema
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UseCaseName { get; set; }
        public string Data { get; set; }

        public string Actor { get; set; }

    }
}
