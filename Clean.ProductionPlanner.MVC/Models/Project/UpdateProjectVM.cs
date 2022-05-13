using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Clean.ProductionPlanner.MVC.Constants;

namespace Clean.ProductionPlanner.MVC.Models
{
    public class UpdateProjectVM
    {
        [Microsoft.Build.Framework.Required]
        public string Name { get; set; }
        [Microsoft.Build.Framework.Required]
        public string Description { get; set; }
        [Microsoft.Build.Framework.Required]
        public string Owner { get; set; }
        [Microsoft.Build.Framework.Required]
        public int Priority { get; set; }
        public List<ProjectTaskVM>? ProjectTasks { get; set; }
        [Display(Name = "Status of the project")]
        [Microsoft.Build.Framework.Required]
        public ProjectProgress? Progress { get; set; }
    }
}