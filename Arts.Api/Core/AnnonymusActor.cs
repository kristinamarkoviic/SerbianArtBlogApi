using Arts.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arts.Api.Core
{
    public class AnnonymusActor : IApplicationActor
    {
        public int Id => 0;
        public string Identity => "Neautorizovan korisnik.";
        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 14, 16, 25, 26, 28 };
    }
}
