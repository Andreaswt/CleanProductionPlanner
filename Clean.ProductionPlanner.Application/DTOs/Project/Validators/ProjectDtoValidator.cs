using Clean.ProductionPlanner.Application.Contracts.Persistence;
using FluentValidation;

namespace Clean.ProductionPlanner.Application.DTOs.Project.Validators
{
    public class ProjectDtoValidator : AbstractValidator<ProjectDto>
    {
        public ProjectDtoValidator()
        {
            Include(new IProjectDtoValidator());
        }
    }
}