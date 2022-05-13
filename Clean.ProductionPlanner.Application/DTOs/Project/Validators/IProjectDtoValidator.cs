using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask.Validators;
using FluentValidation;

namespace Clean.ProductionPlanner.Application.DTOs.Project.Validators
{
    public class IProjectDtoValidator : AbstractValidator<IProjectDto>
    {
        public IProjectDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(x => x.Owner).NotEmpty().WithMessage("{PropertyName} is required");
            
            RuleForEach(x => x.ProjectTasks).SetValidator(new ProjectTaskDtoValidator());
        }
    }
}