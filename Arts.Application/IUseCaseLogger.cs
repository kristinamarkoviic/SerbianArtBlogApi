using System;
using System.Collections.Generic;
using System.Text;

namespace Arts.Application
{
    public interface IUseCaseLogger
    {
        //ovo je da koristimo za logovanje svih akcija svih usera na nivou svakog use case-a
        void Log(IUseCase useCase, IApplicationActor actor, object useCaseData);
    }
}
