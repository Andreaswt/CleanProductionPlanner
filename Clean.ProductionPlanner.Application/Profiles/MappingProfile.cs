using AutoMapper;
using Clean.ProductionPlanner.Application.DTOs;
using Clean.ProductionPlanner.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Clean.ProductionPlanner.Application.DTOs.Day;
using Clean.ProductionPlanner.Application.DTOs.Project;
using Clean.ProductionPlanner.Application.DTOs.ProjectTask;

namespace Clean.ProductionPlanner.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Day, DayDto>().ReverseMap();
            
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Project, CreateProjectDto>().ReverseMap();
            CreateMap<Project, UpdateProjectDto>().ReverseMap();

            CreateMap<ProjectTask, ProjectTaskDto>().ReverseMap();
            CreateMap<ProjectTask, UpdateProjectTaskDto>().ReverseMap();
        }
    }
}
