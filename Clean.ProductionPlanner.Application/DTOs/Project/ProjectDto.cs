using System;
using System.Collections.Generic;
using System.Linq;
using Clean.ProductionPlanner.Application.DTOs.Common;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;
using Clean.ProductionPlanner.Domain.Constants;

namespace Clean.ProductionPlanner.Application.DTOs.Project
{
    public class ProjectDto : BaseDto, IProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public int Priority { get; set; }
        public bool IsProjectTemplate { get; set; }
        public List<ProjectTaskDto>? ProjectTasks { get; set; }
        public DateTime? Created { get; set; }
        public ProjectProgress? Progress { get; set; }
    }
}