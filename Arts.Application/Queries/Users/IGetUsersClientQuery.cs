using Arts.Application.DataTransfer;
using Arts.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.Queries.Users
{
    public interface IGetUsersClientQuery: IQuery<UserSearch, PagedResponse<UserClientDto>>
    {
    }
}
