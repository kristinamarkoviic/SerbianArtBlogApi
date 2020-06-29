using Arts.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.Commands.Likes
{
    public interface ILikePostCommand: ICommand<LikeDto>
    {
    }
}
