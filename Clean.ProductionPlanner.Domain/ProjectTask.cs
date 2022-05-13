using System;
using System.ComponentModel.DataAnnotations;
using Clean.ProductionPlanner.Domain.Common;
using Clean.ProductionPlanner.Domain.Constants;

namespace Clean.ProductionPlanner.Domain
{
    public class ProjectTask : BaseDomainEntity
    {
        public string Name { get; set; }
        public Project Project { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Duration { get; set; }
        public int DurationWhenSorted { get; set; }
        public bool Assigned { get; set; }
        public string? PersonAssigned { get; set; }
        public bool Subtask { get; set; }
        public ProjectTaskProgress Progress { get; set; }
        public Day Day { get; set; }
        public int CompareTo(ProjectTask? other)
        {
            if (other.Priority > this.Priority)
                return -1;
            
            if (other.Priority < this.Priority)
                return 1;
            
            return 0;
        }

        public ProjectTask()
        {
            Progress = ProjectTaskProgress.Todo;
        }
    }
}