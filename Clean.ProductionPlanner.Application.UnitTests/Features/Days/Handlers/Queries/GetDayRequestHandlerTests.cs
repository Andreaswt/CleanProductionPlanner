using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.Features.Days.Handlers.Queries;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Queries;
using Clean.ProductionPlanner.Application.Profiles;
using Clean.ProductionPlanner.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace Clean.ProductionPlanner.Application.UnitTests.Features.Days.Handlers.Queries
{
    public class GetDayRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IDayRepository> _mockRepo;
        public GetDayRequestHandlerTests()
        {
            _mockRepo = MockDayRepository.GetDayRepository();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetDayTest()
        {
            var handler = new GetDayRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetDayRequest() { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<DayDto>();

            result.AvailableHours.ShouldBe(8);
        }
    }
}