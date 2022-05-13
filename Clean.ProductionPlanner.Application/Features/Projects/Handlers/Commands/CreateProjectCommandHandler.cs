using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.Application.Contracts.Persistence;
using Clean.ProductionPlanner.Application.DTOs.Day.Validators;
using Clean.ProductionPlanner.Application.DTOs.Project.Validators;
using Clean.ProductionPlanner.Application.Features.Days.Requests.Commands;
using Clean.ProductionPlanner.Application.Features.Projects.Requests.Commands;
using Clean.ProductionPlanner.Application.Responses;
using Clean.ProductionPlanner.Domain;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Projects.Handlers.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<BaseCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var projectValidator = new CreateProjectDtoValidator();
            var projectValidationResult = await projectValidator.ValidateAsync(request.ProjectDto);

            if (projectValidationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Request Failed";
                response.Errors = projectValidationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var project = _mapper.Map<Project>(request.ProjectDto);
                await _unitOfWork.ProjectRepository.Add(project);
                await _unitOfWork.Save();
                
                response.Success = true;
                response.Message = "Request Created Successfully";
                response.Id = project.Id;
            }

            return response;
        }
    }
}