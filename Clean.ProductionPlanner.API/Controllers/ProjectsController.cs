using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Application.Features.Projects.Requests.Commands;
using Clean.ProductionPlanner.Application.Features.Projects.Requests.Queries;
using Clean.ProductionPlanner.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.ProductionPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> Get(int id)
        {
            var project = await _mediator.Send(new GetProjectRequest { Id = id });
            return Ok(project);
        }

        // GET: api/<ProjectsController>
        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> Get()
        {
            var projects = await _mediator.Send(new GetProjectListRequest());
            return Ok(projects);
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProjectDto project)
        {
            var command = new CreateProjectCommand { ProjectDto = project };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ProjectsController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProjectDto project)
        {
            var command = new UpdateProjectCommand { ProjectDto = project };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
