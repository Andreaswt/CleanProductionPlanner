using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;
using FluentValidation;

namespace Clean.ProductionPlanner.Application.DTOs.ProjectTask.Validators
{
    public class UpdateProjectTaskDtoValidator : AbstractValidator<UpdateProjectTaskDto>
    {
        public UpdateProjectTaskDtoValidator()
        {
            Include(new IProjectTaskDtoValidator());
        }
    }
}