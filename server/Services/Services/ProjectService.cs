using Core;
using DataBaseConnection;
using Services.DTOs;
using Services.Interfaces;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProjectService : IProjectsService
    {
        private readonly DataContext _dataContext;
        private ProjectsServiceMappers _mappers;

        public ProjectService(DataContext dataContext)
        {
            _dataContext = dataContext;
            _mappers = new ProjectsServiceMappers();
        }

        public void AddProject(ProjectDTO projectToAdd)
        {
            _dataContext.Projects.Add(_mappers.MapProjectDTOToProject(projectToAdd));
            _dataContext.SaveChanges();
        }

        public List<ProjectDTO> GetAllProjects()
        {
            List<Project> projects = _dataContext.Projects.ToList();

            return _mappers.MapProjectsToProjectDTOs(projects);
        }

        public List<ProjectDTO> GetProjectsByUserId(string userId)
        {
            List<Project>? projects = _dataContext.Projects
                .Where(p => p.UserId == userId).ToList();

            return _mappers.MapProjectsToProjectDTOs(projects);
        }

        public ProjectDTO GetProjectById(int projectId)
        {
            Project? project = _dataContext.Projects
                .Where(p => p.ProjectId == projectId)
                .SingleOrDefault();

            return _mappers.MapProjectToProjectDTO(project);
        }

        public bool UpdateProject(ProjectDTO projectDTOToUpdate)
        {
            Project newProject = _mappers.MapProjectDTOToProject(projectDTOToUpdate);
            Project? existingProject = _dataContext.Projects.Find(projectDTOToUpdate.ProjectId);
            bool projectExists = false;

            if (existingProject != null)
            {
                _dataContext.Entry(existingProject).CurrentValues.SetValues(newProject);
                _dataContext.SaveChanges();
                projectExists = true;
            }

            return projectExists;
        }

        public bool RemoveProject(int projectId)
        {
            var projectToDelete = _dataContext.Projects.Find(projectId);
            bool projectExists = false;

            if (projectToDelete != null)
            {
                _dataContext.Projects.Remove(projectToDelete);
                _dataContext.SaveChanges();
                projectExists = true;
            }

            return projectExists;
        }

    }
}
