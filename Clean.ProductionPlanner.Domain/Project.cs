using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Clean.ProductionPlanner.Domain.Common;
using Clean.ProductionPlanner.Domain.Constants;

namespace Clean.ProductionPlanner.Domain
{
    public class Project : BaseDomainEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Owner { get; set; }
        public int Priority { get; set; }
        public bool IsProjectTemplate { get; set; }
        public List<ProjectTask>? ProjectTasks { get; set; }
        public DateTime? Created { get; set; }
        public ProjectProgress Progress { get; set; }
        public int? TotalHours
        {
            get
            {
                int totalHours = 0;
                foreach (ProjectTask task in ProjectTasks)
                {
                    totalHours += task.Duration;
                }
                return totalHours;
            }
        }
        public List<ProjectTask> GetSortedProjectTasks()
        {
            return ProjectTasks.OrderBy(t => t.Priority).ToList();
        }

        public Project(ProjectProgress progress)
        {
            Progress = ProjectProgress.Todo;
        }
    }
}