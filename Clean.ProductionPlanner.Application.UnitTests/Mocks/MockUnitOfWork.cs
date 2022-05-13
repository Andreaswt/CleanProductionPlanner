using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Moq;

namespace Clean.ProductionPlanner.Application.UnitTests.Mocks
{
    public class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockDayRepo = MockDayRepository.GetDayRepository();
            var mockProjectRepo = MockProjectRepository.GetProjectRepository();
            var mockProjectTaskRepo = MockProjectTaskRepository.GetProjectTaskRepository();

            mockUow.Setup(r => r.DayRepository).Returns(mockDayRepo.Object);
            mockUow.Setup(r => r.ProjectRepository).Returns(mockProjectRepo.Object);
            mockUow.Setup(r => r.ProjectTaskRepository).Returns(mockProjectTaskRepo.Object);

            return mockUow;
        }
    }
}