using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arts.Application;
using Arts.Application.Commands.Likes;
using Arts.Application.Commands.PieceOfArts;
using Arts.Application.DataTransfer;
using Arts.Application.Queries.PieceOfArts;
using Arts.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PieceOfArtController : ControllerBase
    {

        private readonly IUseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public PieceOfArtController(IUseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }

        [HttpPost]
        [Route("like")]
        public IActionResult Like([FromBody] LikeDto request, [FromServices] ILikePostCommand command)
        {
            request.UserId = actor.Id;

            executor.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }

        // GET: api/PieceOfArt
        [HttpGet]
        public IActionResult Get([FromQuery] PieceOfArtSearch search, [FromServices] IGetPieceOfArtQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/PieceOfArt/5
        [HttpGet("{id}", Name = "GetPieceOfArt")]
        public IActionResult Get(int id, [FromServices] IGetOnePieceOfArtQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/PieceOfArt
        [HttpPost]
        public IActionResult Post([FromForm] PieceOfArtDto dto, [FromServices] ICreatePieceOfArtCommand command )
        {
            dto.UserId = actor.Id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/PieceOfArt/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] PieceOfArtDto dto, [FromServices] IUpdatePieceOfArtCommand command)
        {
            dto.Id = id;
            dto.UserId = actor.Id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePieceOfArtCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
