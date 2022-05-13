using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clean.ProductionPlanner.MVC.Contracts;
using Clean.ProductionPlanner.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Clean.ProductionPlanner.MVC.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProjectService _projectService;

        public ProjectsController(IMapper mapper, IProjectService projectService)
        {
            _mapper = mapper;
            _projectService = projectService;
        }

        // public async Task<ActionResult> Create()
        // {
        //     return View();
        // } 

        // GET: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateProjectVM project)
        {
            if (ModelState.IsValid)
            {
                var response = await _projectService.CreateProject(project);
                if (response.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }

            return RedirectToAction("Error", "Home");
        }
    }
}