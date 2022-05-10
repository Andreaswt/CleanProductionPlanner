using System;
using Clean.ProductionPlanner.Application.DTOs.Common;
using Clean.ProductionPlanner.Domain.Constants;

namespace Clean.ProductionPlanner.Application.DTOs.ProjectTask
{
    public class ProjectTaskDto : BaseDto, IProjectTaskDto
    {
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int? DayId { get; set; }
        public ProjectTaskProgress Progress { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Duration { get; set; }
        public int DurationWhenSorted { get; set; }
        public bool Assigned { get; set; }
        public string? PersonAssigned { get; set; }
        public bool Subtask { get; set; }
        
        public int CompareTo(ProjectTaskDto? other)
        {
            if (other.Priority > this.Priority)
                return -1;
            
            if (other.Priority < this.Priority)
                return 1;
            
            return 0;
        }
    }
}