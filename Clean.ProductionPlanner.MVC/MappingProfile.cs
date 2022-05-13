using AutoMapper;
using Clean.ProductionPlanner.MVC.Models;
using Clean.ProductionPlanner.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.ProductionPlanner.MVC.Services;

namespace Clean.ProductionPlanner.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterVM, RegistrationRequest>().ReverseMap();
            
            CreateMap<ProjectDto, ProjectVM>().ReverseMap();
            CreateMap<CreateProjectDto, CreateProjectVM>().ReverseMap();
            CreateMap<UpdateProjectDto, UpdateProjectVM>().ReverseMap();
            
            CreateMap<ProjectTaskDto, ProjectTaskVM>().ReverseMap();
            CreateMap<UpdateProjectTaskDto, UpdateProjectTaskVM>().ReverseMap();
        }
    }
}
