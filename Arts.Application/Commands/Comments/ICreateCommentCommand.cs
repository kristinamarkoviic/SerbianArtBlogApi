using Arts.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.Commands.Comments
{
    public interface ICreateCommentCommand: ICommand<CommentDto>
    {
    }
}
