using System;
using System.Collections.Generic;
using System.Linq;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Domain;
using Clean.ProductionPlanner.Domain.Constants;
using Moq;

namespace Clean.ProductionPlanner.Application.UnitTests.Mocks
{
    public static class MockProjectTaskRepository
    {
        public static Mock<IProjectTaskRepository> GetProjectTaskRepository()
        {
            
            var projectTasks = new List<ProjectTask>()
            {
                new ProjectTask
                {
                    Name = "Task 1", Duration = 1, Description = "Task 1 Description",
                    Progress = ProjectTaskProgress.Todo, Priority = 1
                },
                new ProjectTask
                {
                    Name = "Task 2", Duration = 2, Description = "Task 2 Description",
                    Progress = ProjectTaskProgress.Todo, Priority = 2
                },
                new ProjectTask
                {
                    Name = "Task 3", Duration = 3, Description = "Task 3 Description",
                    Progress = ProjectTaskProgress.Todo, Priority = 3
                },
                new ProjectTask
                {
                    Name = "Task 4", Duration = 4, Description = "Task 4 Description",
                    Progress = ProjectTaskProgress.Todo, Priority = 4
                },
            };

            var mockRepo = new Mock<IProjectTaskRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(projectTasks);
            
            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return projectTasks.First(x => x.Id == id);
            });
            
            mockRepo.Setup(r => r.Add(It.IsAny<ProjectTask>())).ReturnsAsync((ProjectTask projectTask) => 
            {
                projectTasks.Add(projectTask);
                return projectTask;
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<ProjectTask>()))
                .Callback<ProjectTask>((projectTask) => projectTasks.Remove(projectTask));

            return mockRepo;
        }
    }
}