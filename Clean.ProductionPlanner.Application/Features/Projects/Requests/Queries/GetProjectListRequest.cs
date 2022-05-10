using System;
using System.Collections.Generic;
using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Domain;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Projects.Requests.Queries
{
    public class GetProjectListRequest : IRequest<List<ProjectDto>>
    {
    }
}
