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
    public class DeleteDayCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly DeleteDayCommandHandler _handler;

        public DeleteDayCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new DeleteDayCommandHandler(_mockUow.Object);
        }
        
        [Fact]
        public async Task Day_Deleted()
        {
            await _handler.Handle(new DeleteDayCommand() { Id = 1 }, CancellationToken.None);
            
            var daysAfter = await _mockUow.Object.DayRepository.GetAll();
            
            daysAfter.Count.ShouldBe(2);
        }
    }
}