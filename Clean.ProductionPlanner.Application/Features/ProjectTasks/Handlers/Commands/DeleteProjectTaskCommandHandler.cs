using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day.Validators;
using Clean.ProductionPlanner.Application.Exceptions;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Commands;
using Clean.ProductionPlanner.Application.Features.Projects.Requests.Commands;
using Clean.ProductionPlanner.Application.Features.ProjectTasks.Requests.Commands;
using Clean.ProductionPlanner.Application.Responses;
using Clean.ProductionPlanner.Domain;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.ProjectTasks.Handlers.Commands
{
    public class DeleteProjectTaskCommandHandler : IRequestHandler<DeleteProjectTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectTaskCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Unit> Handle(DeleteProjectTaskCommand request, CancellationToken cancellationToken)
        {
            var projectTask = await _unitOfWork.ProjectTaskRepository.Get(request.Id);

            if (projectTask == null)
                throw new NotFoundException(nameof(ProjectTasks), request.Id);

            await _unitOfWork.ProjectTaskRepository.Delete(projectTask);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}