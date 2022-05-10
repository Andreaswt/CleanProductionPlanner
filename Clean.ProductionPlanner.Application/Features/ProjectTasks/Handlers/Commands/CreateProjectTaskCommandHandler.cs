using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day.Validators;
using Clean.ProductionPlanner.Application.DTOs.Project.Validators;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Commands;
using Clean.ProductionPlanner.Application.Features.Projects.Requests.Commands;
using Clean.ProductionPlanner.Application.Features.ProjectTasks.Requests.Commands;
using Clean.ProductionPlanner.Application.Responses;
using Clean.ProductionPlanner.Domain;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.ProjectTasks.Handlers.Commands
{
    public class CreateProjectTaskCommandHandler : IRequestHandler<CreateProjectTaskCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProjectTaskCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<BaseCommandResponse> Handle(CreateProjectTaskCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new ProjectTaskDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ProjectTaskDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Request Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var projectTask = _mapper.Map<ProjectTask>(request.ProjectTaskDto);

                var project = await _unitOfWork.ProjectRepository.Get(request.ProjectId);
                if (project != null)
                {
                    projectTask.Project = project;
                    
                    await _unitOfWork.ProjectTaskRepository.Add(projectTask);
                    await _unitOfWork.Save();
                    
                    response.Success = true;
                    response.Message = "Request Created Successfully";
                    response.Id = projectTask.Id;
                }
                
                response.Success = false;
                response.Message = "Request failed";
                response.Id = projectTask.Id;
            }

            return response;
        }
    }
}