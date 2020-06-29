using Arts.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.Queries.Categories
{
    public interface IGetOneCategoryQuery: IQuery<int, SingleCategoryDto>
    {
    }
}
