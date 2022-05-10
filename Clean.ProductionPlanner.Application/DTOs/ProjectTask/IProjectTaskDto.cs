using Clean.ProductionPlanner.Application.DTOs.Project;

namespace Clean.ProductionPlanner.Application.DTOs.ProjectTask
{
    public interface IProjectTaskDto
    {
        public string Name { get; set; }
        public ProjectDto Project { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Duration { get; set; }
        public string? PersonAssigned { get; set; }
    }
}