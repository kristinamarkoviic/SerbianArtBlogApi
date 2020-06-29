using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arts.Application;
using Arts.Application.Commands;
using Arts.Application.DataTransfer;
using Arts.Application.Queries;
using Arts.Application.Searches;
using Arts.DataAccess;
using Arts.Implementation.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {


        private readonly IApplicationActor actor;
        private readonly IUseCaseExecutor executor;

        public CountriesController(IApplicationActor actor, IUseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
            // GET: api/Countries
            [HttpGet]
        public IActionResult Get(
                [FromQuery] CountrySearch search, [FromServices] IGetCountriesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Countries/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Countries
        [HttpPost]
        public IActionResult Post([FromBody] CountryDto dto, [FromServices] ICreateCountryCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CountryDto dto, [FromServices] IUpdateCountryCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCountryCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
