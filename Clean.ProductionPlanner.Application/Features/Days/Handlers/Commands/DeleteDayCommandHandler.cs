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
    public class DeleteDayCommandHandler : IRequestHandler<DeleteDayCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDayCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Unit> Handle(DeleteDayCommand request, CancellationToken cancellationToken)
        {
            var day = await _unitOfWork.DayRepository.Get(request.Id);

            if (day == null)
                throw new NotFoundException(nameof(Day), request.Id);

            await _unitOfWork.DayRepository.Delete(day);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}