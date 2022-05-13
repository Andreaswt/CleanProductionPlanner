using System;
using System.Collections.Generic;

namespace Clean.ProductionPlanner.MVC.Models
{
    public class DayVM
    {
        public int Id { get; set; }
        public List<ProjectTaskVM>? Tasks { get; set; }
        public DateTime Date { get; set; }
        public int AvailableHours { get; set; }
        public int HoursLeftToBook { get; set; }
    }
}