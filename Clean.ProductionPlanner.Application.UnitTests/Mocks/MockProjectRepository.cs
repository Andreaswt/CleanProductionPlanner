using System;
using System.Collections.Generic;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Domain;
using Clean.ProductionPlanner.Domain.Constants;
using Moq;

namespace Clean.ProductionPlanner.Application.UnitTests.Mocks
{
    public class MockProjectRepository
    {
        public static Mock<IProjectRepository> GetProjectRepository()
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
            
            var projects = new List<Project>()
            {
                new Project {Id = 1, Name = "Project 1", Description = "Project 1 description", ProjectTasks = projectTasks },
                new Project {Id = 2, Name = "Project 2", Description = "Project 2 description", ProjectTasks = projectTasks },
                new Project {Id = 3, Name = "Project 3", Description = "Project 3 description", ProjectTasks = projectTasks },
            };

            var mockRepo = new Mock<IProjectRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(projects);
            
            mockRepo.Setup(r => r.Add(It.IsAny<Project>())).ReturnsAsync((Project project) => 
            {
                projects.Add(project);
                return project;
            });

            return mockRepo;
        }
    }
}