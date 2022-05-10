using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day.Validators;
using Clean.ProductionPlanner.Application.DTOs.Project.Validators;
using Clean.ProductionPlanner.Application.Exceptions;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Commands;
using Clean.ProductionPlanner.Application.Features.Projects.Requests.Commands;
using Clean.ProductionPlanner.Application.Features.ProjectTasks.Requests.Commands;
using Clean.ProductionPlanner.Application.Responses;
using Clean.ProductionPlanner.Domain;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.ProjectTasks.Handlers.Commands
{
    public class UpdateProjectTaskCommandHandler : IRequestHandler<UpdateProjectTaskCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProjectTaskCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Unit> Handle(UpdateProjectTaskCommand request, CancellationToken cancellationToken)
        {
            var projectTask = await _unitOfWork.ProjectTaskRepository.Get(request.Id);

            if(projectTask is null)
                throw new NotFoundException(nameof(ProjectTask), request.Id);

            var validator = new ProjectTaskDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ProjectTaskDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            _mapper.Map(request.ProjectTaskDto, projectTask);

            await _unitOfWork.ProjectTaskRepository.Update(projectTask);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}