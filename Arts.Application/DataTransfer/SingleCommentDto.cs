using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.DataTransfer
{
    public class SingleCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ParentId { get; set; }
        public UserClientDto User { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<SingleCommentDto> Children { get; set; } = new List<SingleCommentDto>();
    }
}
