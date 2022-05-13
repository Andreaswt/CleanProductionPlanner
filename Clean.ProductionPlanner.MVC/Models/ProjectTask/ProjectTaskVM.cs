using System;
using System.Collections.Generic;
using Clean.ProductionPlanner.MVC.Constants;

namespace Clean.ProductionPlanner.MVC.Models
{
    public class ProjectTaskVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProjectVM Project { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Duration { get; set; }
        public int DurationWhenSorted { get; set; }
        public bool Assigned { get; set; }
        public string? PersonAssigned { get; set; }
        public bool Subtask { get; set; }
        public ProjectTaskProgress Progress { get; set; }
        public DayVM Day { get; set; }
    }
}