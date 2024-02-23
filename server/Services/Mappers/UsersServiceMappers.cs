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
                UserId = user.Id,
                Email = user.Email,
            };

            return userDTO;
        }

        public User MapUserDTOToUser(UserDTO userDTO)
        {
            User user = new User
            {
                Id = userDTO.UserId,
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

    }
}
