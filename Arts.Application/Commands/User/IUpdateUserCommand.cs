using Arts.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.Commands
{
    public interface IUpdateUserCommand: ICommand<UserDto>
    {
    }
}
