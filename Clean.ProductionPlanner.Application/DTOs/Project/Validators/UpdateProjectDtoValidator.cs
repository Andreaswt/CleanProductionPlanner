using Clean.ProductionPlanner.Application.Contracts.Persistence;
using FluentValidation;

namespace Clean.ProductionPlanner.Application.DTOs.Project.Validators
{
    public class UpdateProjectDtoValidator : AbstractValidator<UpdateProjectDto>
    {
        public UpdateProjectDtoValidator()
        {
            Include(new IProjectDtoValidator());
        }
    }
}