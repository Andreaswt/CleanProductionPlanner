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
using Clean.ProductionPlanner.Application.Features.Projects.Handlers.Commands;
using Clean.ProductionPlanner.Application.Features.Projects.Requests.Commands;
using Clean.ProductionPlanner.Application.Profiles;
using Clean.ProductionPlanner.Application.Responses;
using Clean.ProductionPlanner.Application.UnitTests.Mocks;
using Clean.ProductionPlanner.Domain;
using Clean.ProductionPlanner.Domain.Constants;
using Moq;
using Shouldly;
using Xunit;

namespace Clean.ProductionPlanner.Application.UnitTests.Features.Projects.Handlers.Commands
{
    public class DeleteProjectCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly DeleteProjectCommandHandler _handler;

        public DeleteProjectCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new DeleteProjectCommandHandler(_mockUow.Object);
        }
        
        [Fact]
        public async Task Project_Deleted()
        {
            await _handler.Handle(new DeleteProjectCommand() { Id = 1 }, CancellationToken.None);
            
            var projectExists = await _mockUow.Object.ProjectRepository.Exists(1);
            projectExists.ShouldBeFalse();
        }
    }
}