using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day.Validators;
using Clean.ProductionPlanner.Application.Exceptions;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Commands;
using Clean.ProductionPlanner.Application.Responses;
using Clean.ProductionPlanner.Domain;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Days.Handlers.Commands
{
    public class UpdateDayCommandHandler : IRequestHandler<UpdateDayCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDayCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Unit> Handle(UpdateDayCommand request, CancellationToken cancellationToken)
        {
            var day = await _unitOfWork.DayRepository.Get(request.Id);

            if(day is null)
                throw new NotFoundException(nameof(Day), request.Id);

            if (request.DayDto != null)
            {
                var validator = new DayDtoValidator();
                var validationResult = await validator.ValidateAsync(request.DayDto);
                if (validationResult.IsValid == false)
                    throw new ValidationException(validationResult);

                _mapper.Map(request.DayDto, day);

                await _unitOfWork.DayRepository.Update(day);
                await _unitOfWork.Save();
            }

            return Unit.Value;
        }
    }
}