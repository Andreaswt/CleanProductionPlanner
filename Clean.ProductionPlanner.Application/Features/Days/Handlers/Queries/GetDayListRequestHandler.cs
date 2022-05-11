using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Queries;
using Clean.ProductionPlanner.Domain;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Days.Handlers.Queries
{
    public class GetDayListRequestHandler : IRequestHandler<GetDayListRequest, List<DayDto>>
    {
        private readonly IDayRepository _dayRepository;
        private readonly IMapper _mapper;

        public GetDayListRequestHandler(IDayRepository dayRepository,
            IMapper mapper)
        {
            _dayRepository = dayRepository;
            _mapper = mapper;
        }
        
        public async Task<List<DayDto>> Handle(GetDayListRequest request, CancellationToken cancellationToken)
        {
            if (request.FromDate == null && request.EndDate == null)
            {
                return  _mapper.Map<List<DayDto>>(await _dayRepository.GetAll());
            }
            
            return  _mapper.Map<List<DayDto>>(await _dayRepository.GetBetweenDates(request.FromDate,request.EndDate));
        }
    }
}