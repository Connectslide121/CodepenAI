using Core;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    internal class UsersServiceMappers
    {
        public UserDTO MapUserToUserDTO(User user)
        {
            UserDTO userDTO = new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate,
                Projects = MapProjectsToProjectDTOs(user.Projects),
            };

            return userDTO;
        }

        public User MapUserDTOToUser(UserDTO userDTO)
        {
            User user = new User
            {
                UserId = userDTO.UserId,
                UserName = userDTO.UserName,
                Password = userDTO.Password,
                Email = userDTO.Email,
                RegistrationDate = userDTO.RegistrationDate,
            };

            return user;
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
                    TotalMoney = project.TotalMoney
                };

                projectDTOs.Add(projectDTO);
            }

            return projectDTOs;
        }

        public List<Project> MapProjectDTOsToProjects(List<ProjectDTO> projectDTOs)
        {
            List<Project> projects = new List<Project>();

            foreach (ProjectDTO projectDTO in projectDTOs)
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
                    TotalMoney = projectDTO.TotalMoney
                };

                projects.Add(project);
            }

            return projects;
        }
    }
}
