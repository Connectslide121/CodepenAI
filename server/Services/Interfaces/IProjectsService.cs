using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProjectsService
    {
        void AddProject(ProjectDTO project);
        List<ProjectDTO> GetAllProjects();
        List<ProjectDTO> GetProjectsByUserId(string userId);
        ProjectDTO GetProjectById(int projectId);
        bool UpdateProject(ProjectDTO project);
        bool RemoveProject(int projectId);
    }
}
