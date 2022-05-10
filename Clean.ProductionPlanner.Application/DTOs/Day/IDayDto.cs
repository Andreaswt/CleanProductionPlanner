using System;
using System.Collections.Generic;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;

namespace Clean.ProductionPlanner.Application.DTOs.Day
{
    public interface IDayDto
    {
        public List<ProjectTaskDto>? Tasks { get; set; }
        public DateTime Date { get; set; }
        public int AvailableHours { get; set; }
        public int HoursLeftToBook { get; set; }
    }
}