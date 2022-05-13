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
using Clean.ProductionPlanner.Application.Responses;
using Clean.ProductionPlanner.Domain;
using MediatR;

namespace Clean.ProductionPlanner.Application.Features.Projects.Handlers.Commands
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.ProjectRepository.Get(request.Id);

            if(project is null)
                throw new NotFoundException(nameof(Project), request.Id);

            var validator = new UpdateProjectDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ProjectDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            _mapper.Map(request.ProjectDto, project);

            await _unitOfWork.ProjectRepository.Update(project);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}