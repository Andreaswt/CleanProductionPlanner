using System;
using Clean.ProductionPlanner.Application.DTOs.Common;
using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Domain.Constants;

namespace Clean.ProductionPlanner.Application.DTOs.ProjectTask
{
    public class CreateProjectTaskDto : BaseDto
    {
        public string Name { get; set; }
        public ProjectDto Project { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Duration { get; set; }
        public string? PersonAssigned { get; set; }
    }
}