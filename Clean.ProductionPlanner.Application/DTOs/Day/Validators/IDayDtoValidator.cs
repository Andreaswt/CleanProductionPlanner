using Clean.ProductionPlanner.Application.Contracts.Persistence;
using FluentValidation;

namespace Clean.ProductionPlanner.Application.DTOs.Day.Validators
{
    public class IDayDtoValidator : AbstractValidator<IDayDto>
    {
        public IDayDtoValidator()
        {
            RuleFor(p => p.AvailableHours)
                .LessThan(p => p.HoursLeftToBook).WithMessage("{PropertyName} must be larger than {ComparisonValue}");
        }
    }
}