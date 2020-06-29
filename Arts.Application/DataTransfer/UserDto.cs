using Arts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.DataTransfer
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int CountryId { get; set; }
        public CountryDto Country { get; set; }
        //zakljcak ovde je ok  za countryId

        public IEnumerable<int> useCasesForUser { get; set; } = new List<int>();
    }
}
