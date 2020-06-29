using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arts.Application;
using Arts.Application.Queries.Users;
using Arts.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontendUserController : ControllerBase
    {

        private readonly IUseCaseExecutor executor;

        public FrontendUserController(IUseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/FrontendUser
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersClientQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/FrontendUser/5
        [HttpGet("{id}", Name = "GetClientUsers")]
        public IActionResult Get(int id, [FromServices] IGetOneUserClientQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/FrontendUser
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FrontendUser/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
