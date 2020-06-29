using Arts.Application;
using Arts.DataAccess;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Arts.Implementation.Logging
{
    public class UseCaseLogger : IUseCaseLogger
    {
        private readonly ArtsContext context;
        private readonly IMapper mapper;
        public UseCaseLogger(ArtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            context.UseCaseLogs.Add(new Domain.Entities.UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name

            });

            context.SaveChanges();
            
        }
    }
}
