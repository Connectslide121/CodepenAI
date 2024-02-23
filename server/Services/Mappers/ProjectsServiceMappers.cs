using Core;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    internal class ProjectsServiceMappers
    {
        public ProjectDTO MapProjectToProjectDTO(Project project)
        {
            if (project != null)
            {
                ProjectDTO projectDTO = new ProjectDTO
                {
                    ProjectId = project.ProjectId,
                    UserId = project.UserId,
                    Title = project.Title,
                    Description = project.Description,
                    HtmlCode = project.HtmlCode,
                    CssCode = project.CssCode,
                    JsCode = project.JsCode,
                    CreatedAt = project.CreatedAt,
                    UpdatedAt = project.UpdatedAt,
                    TotalTokens = project.TotalTokens,
                    TotalMoney = project.TotalMoney,
                };

                return projectDTO;

            }
            else return new ProjectDTO();
        }

        public Project MapProjectDTOToProject(ProjectDTO projectDTO)
        {
            Project project = new Project
            {
                ProjectId = projectDTO.ProjectId,
                UserId = projectDTO.UserId,
                Title = projectDTO.Title,
                Description = projectDTO.Description,
                HtmlCode = projectDTO.HtmlCode,
                CssCode = projectDTO.CssCode,
                JsCode = projectDTO.JsCode,
                CreatedAt = projectDTO.CreatedAt,
                UpdatedAt = projectDTO.UpdatedAt,
                TotalTokens = projectDTO.TotalTokens,
                TotalMoney = projectDTO.TotalMoney,
            };

            return project;
        }

        public List<ProjectDTO> MapProjectsToProjectDTOs(List<Project> projects)
        {
            List<ProjectDTO> projectDTOs = new List<ProjectDTO>();

            foreach (Project project in projects)
            {
                ProjectDTO projectDTO = new ProjectDTO
                {
                    ProjectId = project.ProjectId,
                    UserId = project.UserId,
                    Title = project.Title,
                    Description = project.Description,
                    HtmlCode = project.HtmlCode,
                    CssCode = project.CssCode,
                    JsCode = project.JsCode,
                    CreatedAt = project.CreatedAt,
                    UpdatedAt = project.UpdatedAt,
                    TotalTokens = project.TotalTokens,
                    TotalMoney = project.TotalMoney,
                };

                projectDTOs.Add(projectDTO);
            }

            return projectDTOs;
        }

        public UserDTO MapUserToUserDTO(User user)
        {
            UserDTO userDTO = new UserDTO
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate,
            };

            return userDTO;

        }

        public User MapUserDTOtoUser(UserDTO userDTO)
        {
            User user = new User
            {
                Id = userDTO.UserId,
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                RegistrationDate = userDTO.RegistrationDate,
            };

            return user;

        }
    }
}
