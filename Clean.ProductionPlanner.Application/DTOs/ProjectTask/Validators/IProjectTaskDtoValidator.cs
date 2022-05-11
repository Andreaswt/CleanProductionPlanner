using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;
using FluentValidation;

namespace Clean.ProductionPlanner.Application.DTOs.Project.Validators
{
    public class IProjectTaskDtoValidator : AbstractValidator<IProjectTaskDto>
    {
        public IProjectTaskDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(x => x.Priority)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be at least {ComparisonValue}.");

            RuleFor(x => x.Duration)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be at least {ComparisonValue}.");
            
            RuleFor(x => x.PersonAssigned).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}