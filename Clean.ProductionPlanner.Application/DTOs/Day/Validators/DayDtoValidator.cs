using Clean.ProductionPlanner.Application.Contracts.Persistence;
using FluentValidation;

namespace Clean.ProductionPlanner.Application.DTOs.Day.Validators
{
    public class DayDtoValidator : AbstractValidator<DayDto>
    {
        public DayDtoValidator()
        {
            Include(new IDayDtoValidator());
        }
    }
}