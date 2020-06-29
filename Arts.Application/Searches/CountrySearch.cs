using Arts.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.Searches
{
    public class CountrySearch: PagedSearch
    {
        public string Name { get; set; }
    }
}
