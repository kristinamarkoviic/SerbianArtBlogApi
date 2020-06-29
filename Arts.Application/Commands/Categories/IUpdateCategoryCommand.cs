using Arts.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.Commands.Categories
{
    public interface IUpdateCategoryCommand: ICommand<CategoryDto>
    {
    }
}
