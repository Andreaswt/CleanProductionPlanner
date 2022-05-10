namespace Clean.ProductionPlanner.Application.DTOs.ProjectTask
{
    public interface IProjectTaskDto
    {
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Duration { get; set; }
        public string? PersonAssigned { get; set; }
    }
}