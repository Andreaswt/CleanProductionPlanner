using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;
using Clean.ProductionPlanner.Application.Features.Days.Handlers.Commands;
using Clean.ProductionPlanner.Application.Features.Days.Handlers.Queries;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Commands;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Queries;
using Clean.ProductionPlanner.Application.Profiles;
using Clean.ProductionPlanner.Application.Responses;
using Clean.ProductionPlanner.Application.UnitTests.Mocks;
using Clean.ProductionPlanner.Domain;
using Clean.ProductionPlanner.Domain.Constants;
using Moq;
using Shouldly;
using Xunit;

namespace Clean.ProductionPlanner.Application.UnitTests.Features.Days.Handlers.Commands
{
    public class UpdateDayCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly UpdateDayCommandHandler _handler;
        private readonly DayDto _dayDto;

        public UpdateDayCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdateDayCommandHandler(_mockUow.Object, _mapper);
        }
        
        [Fact]
        public async Task Valid_Day_Updated()
        {
            var day = await _mockUow.Object.DayRepository.Get(1);
            day.HoursLeftToBook = 4;
            
            await _handler.Handle(new UpdateDayCommand() { Id = 1, DayDto = _dayDto }, CancellationToken.None);
            
            var updatedDay = await _mockUow.Object.DayRepository.Get(1);
            
            updatedDay.HoursLeftToBook.ShouldBe(4);
        }
    }
}