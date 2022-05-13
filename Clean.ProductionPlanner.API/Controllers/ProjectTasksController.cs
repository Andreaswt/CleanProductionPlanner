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
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;
using Clean.ProductionPlanner.Application.Features.ProjectTasks.Requests.Commands;
using Clean.ProductionPlanner.Application.Features.ProjectTasks.Requests.Queries;

namespace Clean.ProductionPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectTasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectTasksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET api/<ProjectTasksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTaskDto>> Get(int id)
        {
            var projectTask = await _mediator.Send(new GetProjectTaskRequest { Id = id });
            return Ok(projectTask);
        }

        // PUT api/<ProjectTasksController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProjectTaskDto projectTask, int id)
        {
            var command = new UpdateProjectTaskCommand { ProjectTaskDto = projectTask, Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ProjectTasksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
