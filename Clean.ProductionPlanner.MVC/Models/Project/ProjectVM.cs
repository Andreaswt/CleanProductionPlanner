using System;
using System.Collections.Generic;
using Clean.ProductionPlanner.MVC.Constants;

namespace Clean.ProductionPlanner.MVC.Models
{
    public class ProjectVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public int Priority { get; set; }
        public bool IsProjectTemplate { get; set; }
        public List<ProjectTaskVM>? ProjectTasks { get; set; }
        public DateTime? Created { get; set; }
        public ProjectProgress? Progress { get; set; }
    }
}