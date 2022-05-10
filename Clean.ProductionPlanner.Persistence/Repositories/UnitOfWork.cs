
using AutoMapper;
using Clean.ProductionPlanner.Application.Constants;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clean.ProductionPlanner.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProductionPlannerDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IDayRepository _dayRepository;
        private IProjectRepository _projectRepository;
        private IProjectTaskRepository _projectTaskRepository;


        public UnitOfWork(ProductionPlannerDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }
        
        public IDayRepository DayRepository => 
            _dayRepository ??= new DayRepository(_context);
        public IProjectRepository ProjectRepository => 
            _projectRepository ??= new ProjectRepository(_context);
        public IProjectTaskRepository ProjectTaskRepository => 
            _projectTaskRepository ??= new ProjectTaskRepository(_context);
        
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save() 
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            await _context.SaveChangesAsync(username);
        }
    }
}
