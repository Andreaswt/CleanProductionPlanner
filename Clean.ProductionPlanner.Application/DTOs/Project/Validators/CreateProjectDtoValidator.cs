using Clean.ProductionPlanner.Application.Contracts.Persistence;
using FluentValidation;

namespace Clean.ProductionPlanner.Application.DTOs.Project.Validators
{
    public class CreateProjectDtoValidator : AbstractValidator<CreateProjectDto>
    {
        public CreateProjectDtoValidator()
        {
            Include(new IProjectDtoValidator());
        }
    }
}