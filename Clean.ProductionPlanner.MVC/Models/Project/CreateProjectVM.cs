using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clean.ProductionPlanner.MVC.Models
{
    public class CreateProjectVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Owner { get; set; }
        [Display(Name = "Is project a template for other projects?")]
        [Required]
        public bool IsProjectTemplate { get; set; }
        public List<ProjectTaskVM> ProjectTasks { get; set; }
    }
}