using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.DataTransfer
{
    public class PieceOfArtDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public IFormFile Picture { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
        
    }
}
