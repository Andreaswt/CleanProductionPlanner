using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clean.ProductionPlanner.Domain.Common;

namespace Clean.ProductionPlanner.Domain
{
    public class Day : BaseDomainEntity
    {
        public List<ProjectTask>? Tasks { get; set; }
        public DateTime Date { get; set; }
        public int AvailableHours { get; set; }
        public int HoursLeftToBook { get; set; }
    }
}