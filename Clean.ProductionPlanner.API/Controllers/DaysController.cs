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
using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Queries;

namespace Clean.ProductionPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DaysController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DaysController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET api/<DaysController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayDto>> Get(int id)
        {
            var day = await _mediator.Send(new GetDayRequest() { Id = id });
            return Ok(day);
        }
        
        // GET: api/<DaysController>
        [HttpGet("byDates")]
        public async Task<ActionResult<List<DayDto>>> Get(DateTime fromDate, DateTime endDate)
        {
            var days = await _mediator.Send(new GetDayListRequest() { FromDate = fromDate, EndDate = endDate });
            return Ok(days);
        }

        // GET: api/<DaysController>
        [HttpGet]
        public async Task<ActionResult<List<DayDto>>> Get()
        {
            var days = await _mediator.Send(new GetDayListRequest());
            return Ok(days);
        }
    }
}
