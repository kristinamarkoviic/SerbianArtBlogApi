using Arts.Application.DataTransfer;
using Arts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.Commands
{
    public interface ICreateUserCommand: ICommand<UserDto>
    {
    }
}
