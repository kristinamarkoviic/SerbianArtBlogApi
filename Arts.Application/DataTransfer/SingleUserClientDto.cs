using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.DataTransfer
{
    public class SingleUserClientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public CountryDto Country { get; set; }
        public string Email { get; set; }
        public ICollection<PieceOfArtDto> PieceOfArts { get; set; } = new List<PieceOfArtDto>();
    }
}
