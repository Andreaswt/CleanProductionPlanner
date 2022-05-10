using System.Collections.Generic;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;

namespace Clean.ProductionPlanner.Application.DTOs.Project
{
    public interface IProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public bool IsProjectTemplate { get; set; }
        public List<ProjectTaskDto>? ProjectTasks { get; set; }
    }
}