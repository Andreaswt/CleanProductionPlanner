using System;
using System.Collections.Generic;
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
    public class CreateDayCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly DayDto _dayDto;
        private readonly CreateDayCommandHandler _handler;

        public CreateDayCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateDayCommandHandler(_mockUow.Object, _mapper);

            ProjectDto project = new ProjectDto()
            {
                Id = 1,
                Name = "Project 1",
                Description = "Project 1 description"
            };

            var projectTasks = new List<ProjectTaskDto>()
            {
                new ProjectTaskDto
                {
                    Name = "Task 1", Duration = 1, Description = "Task 1 Description",
                    Progress = ProjectTaskProgress.Todo, Priority = 1, Project = project
                },
            };

            _dayDto = new DayDto
                {Id = 1, AvailableHours = 8, HoursLeftToBook = 8, Date = DateTime.Today, Tasks = projectTasks};
        }
        
        [Fact]
        public async Task Valid_Day_Added()
        {
            var result = await _handler.Handle(new CreateDayCommand() { DayDto = _dayDto }, CancellationToken.None);

            var days = await _mockUow.Object.DayRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();

            days.Count.ShouldBe(4);
        }
        
        [Fact]
        public async Task Invalid_Day_Added()
        {
            _dayDto.AvailableHours = -1;
            _dayDto.HoursLeftToBook = -1;
            
            var result = await _handler.Handle(new CreateDayCommand() { DayDto = _dayDto }, CancellationToken.None);

            var days = await _mockUow.Object.DayRepository.GetAll();

            days.Count.ShouldBe(4);
            
            result.ShouldBeOfType<BaseCommandResponse>();
        }
    }
}