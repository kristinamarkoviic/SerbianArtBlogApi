using Arts.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application.Commands.PieceOfArts
{
    public interface ICreatePieceOfArtCommand: ICommand<PieceOfArtDto>
    {
    }
}
