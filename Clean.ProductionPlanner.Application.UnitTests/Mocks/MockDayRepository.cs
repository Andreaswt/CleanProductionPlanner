using System;
using System.Collections.Generic;
using System.Linq;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Domain;
using Clean.ProductionPlanner.Domain.Constants;
using Moq;

namespace Clean.ProductionPlanner.Application.UnitTests.Mocks
{
    public static class MockDayRepository
    {
        public static Mock<IDayRepository> GetDayRepository()
        {
            Project project = new Project()
            {
                Id = 1,
                Name = "Project 1",
                Description = "Project 1 description"
            };

            var projectTasks = new List<ProjectTask>()
            {
                new ProjectTask
                {
                    Name = "Task 1", Duration = 1, Description = "Task 1 Description",
                    Progress = ProjectTaskProgress.Todo, Priority = 1, Project = project
                },
                new ProjectTask
                {
                    Name = "Task 2", Duration = 2, Description = "Task 2 Description",
                    Progress = ProjectTaskProgress.Todo, Priority = 2, Project = project
                },
                new ProjectTask
                {
                    Name = "Task 3", Duration = 3, Description = "Task 3 Description",
                    Progress = ProjectTaskProgress.Todo, Priority = 3, Project = project
                },
                new ProjectTask
                {
                    Name = "Task 4", Duration = 4, Description = "Task 4 Description",
                    Progress = ProjectTaskProgress.Todo, Priority = 4, Project = project
                },
            };
            
            var days = new List<Day>
            {
                new Day {Id = 1, AvailableHours = 8, HoursLeftToBook = 8, Date = DateTime.Today, Tasks = projectTasks},
                new Day {Id = 2, AvailableHours = 8, HoursLeftToBook = 8, Date = DateTime.Today.AddDays(1), Tasks = projectTasks},
                new Day {Id = 3, AvailableHours = 8, HoursLeftToBook = 8, Date = DateTime.Today.AddDays(2), Tasks = projectTasks}
            };
            
            var mockRepo = new Mock<IDayRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(days);
            
            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return days.First(x => x.Id == id);
            });
            
            mockRepo.Setup(r => r.Add(It.IsAny<Day>())).ReturnsAsync((Day day) => 
            {
                days.Add(day);
                return day;
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Day>()))
                .Callback<Day>((day) => days.Remove(day));

            return mockRepo;
        }
    }
}