using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.DataTransfer
{
    public class SingleUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public CountryDto Country { get; set; }
        public IEnumerable<int> useCasesForUser { get; set; } = new List<int>();
        public ICollection<PieceOfArtDto> PieceOfArts { get; set; } = new List<PieceOfArtDto>();
    }
}
