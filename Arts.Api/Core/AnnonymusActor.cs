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

        //public IEnumerable<int> AllowedUseCases => new List<int> { 1,2,3,4,5,6,7,8,9,10,11,12,13,14 };
        //public IEnumerable<int> AllowedUseCases => new List<int> { 1,7,8,9,10,11,12,13,14,15,16,17,18,19,20,24,28,29,30 };
        public IEnumerable<int> AllowedUseCases => new List<int> { 28,29,30,31,32,33 };
    }
}
