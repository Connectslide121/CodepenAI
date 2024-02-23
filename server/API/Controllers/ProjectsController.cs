using API.InputModels;
using API.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;
using Services.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;
        private ProjectsControllerMappers _mappers;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
            _mappers = new ProjectsControllerMappers();
        }

        [HttpGet("all")]

        public IActionResult GetAllProjects()
        {
            List<ProjectDTO> projectDTOs = _projectsService.GetAllProjects();
            return projectDTOs == null ? NotFound() : Ok(projectDTOs);
        }

        [HttpGet("user/{userId}")]

        public IActionResult GetProjectsByUserId(string userId)
        {
            List<ProjectDTO> projectsByUserId = _projectsService.GetProjectsByUserId(userId);
            return projectsByUserId == null ? NotFound() : Ok(projectsByUserId);
        }


        [HttpGet("project/{projectId}")]

        public IActionResult GetProjectById(int projectId)
        {
            ProjectDTO projectById = _projectsService.GetProjectById(projectId);
            return projectById == null ? NotFound() : Ok(projectById);
        }

        [HttpPost("create")]
        public void CreateProject([FromBody] ProjectInputModelToCreate model)
        {
            ProjectDTO projectDTO = _mappers.MapModelToProjectDTOToAdd(model);
            _projectsService.AddProject(projectDTO);
        }

        [HttpPut("update")]

        public IActionResult UpdateProject(ProjectInputModelToUpdate model)
        {
            ProjectDTO projectDTO = _mappers.MapModelToProjectDTOToUpdate(model);
            bool projectUpdated = _projectsService.UpdateProject(projectDTO);

            return projectUpdated == false ? NotFound() : Ok(projectDTO);
        }

        [HttpDelete("delete/{projectId}")]

        public IActionResult DeleteProject(int projectId)
        {
            bool projectDeleted = _projectsService.RemoveProject(projectId);

            return projectDeleted == false ? NotFound() : Ok(projectId);
        }
    }
}
