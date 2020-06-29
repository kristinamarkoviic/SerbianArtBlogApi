using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.DataTransfer
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PieceOfArtId { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
    }
}
