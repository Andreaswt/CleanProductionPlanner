using Microsoft.Build.Framework;

namespace Clean.ProductionPlanner.MVC.Models
{
    public class UpdateProjectTaskVM
    {
        [Required]
        public string Name { get; set; }
        public ProjectVM Project { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        public int Duration { get; set; }
        public string? PersonAssigned { get; set; }
    }
}