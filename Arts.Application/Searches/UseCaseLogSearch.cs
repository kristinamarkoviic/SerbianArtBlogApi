using Arts.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.Searches
{
    public class UseCaseLogSearch: PagedSearch
    {
        public string Actor { get; set; }
        public string UseCaseName { get; set; }
        public string DateStart { get; set; }
        public string DateEnd  { get; set; }
    }
}
