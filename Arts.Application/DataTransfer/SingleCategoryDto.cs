using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.DataTransfer
{
    public class SingleCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PieceOfArtClientDto> PieceOfArts { get; set; } = new List<PieceOfArtClientDto>();
    }
}
