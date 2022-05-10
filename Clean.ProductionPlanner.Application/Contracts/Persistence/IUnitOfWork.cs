using System;
using System.Threading.Tasks;

namespace Clean.ProductionPlanner.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IDayRepository DayRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IProjectTaskRepository ProjectTaskRepository { get; }
        Task Save();
    }
}
