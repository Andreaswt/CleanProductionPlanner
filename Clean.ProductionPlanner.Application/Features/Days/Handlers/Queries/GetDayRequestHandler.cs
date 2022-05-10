using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Queries;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Days.Handlers.Queries
{
    public class GetDayRequestHandler : IRequestHandler<GetDayRequest, DayDto>
    {
        private readonly IDayRepository _dayRepository;
        private readonly IMapper _mapper;

        public GetDayRequestHandler(IDayRepository dayRepository,
            IMapper mapper)
        {
            _dayRepository = dayRepository;
            _mapper = mapper;
        }
        
        public async Task<DayDto> Handle(GetDayRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<DayDto>(await _dayRepository.Get(request.Id));
        }
    }
}