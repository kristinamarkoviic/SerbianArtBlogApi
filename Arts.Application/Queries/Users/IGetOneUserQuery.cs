using Arts.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.Queries.Users
{
    public interface IGetOneUserQuery: IQuery<int, SingleUserDto>
    {
    }
}
