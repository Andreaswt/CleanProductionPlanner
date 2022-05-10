using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day.Validators;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Commands;
using Clean.ProductionPlanner.Application.Responses;
using Clean.ProductionPlanner.Domain;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Days.Handlers.Commands
{
    public class CreateDayCommandHandler : IRequestHandler<CreateDayCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDayCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<BaseCommandResponse> Handle(CreateDayCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new DayDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DayDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Request Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var day = _mapper.Map<Day>(request.DayDto);
                await _unitOfWork.DayRepository.Add(day);
                await _unitOfWork.Save();
                
                response.Success = true;
                response.Message = "Request Created Successfully";
                response.Id = day.Id;
            }

            return response;
        }
    }
}