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

            mockUow.Setup(r => r.DayRepository).Returns(mockDayRepo.Object);

            return mockUow;
        }
    }
}