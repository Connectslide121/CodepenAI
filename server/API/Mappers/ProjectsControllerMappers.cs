using API.InputModels;
using Services.DTOs;

namespace API.Mappers
{
    public class ProjectsControllerMappers
    {
        public ProjectDTO MapModelToProjectDTOToAdd(ProjectInputModelToCreate model)
        {
            ProjectDTO projectDTO = new ProjectDTO
            {
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                HtmlCode = model.HtmlCode,
                CssCode = model.CssCode,
                JsCode = model.JsCode,
                CreatedAt = DateTime.Now,
                TotalTokens = model.TotalTokens,
                TotalMoney = model.TotalMoney
            };

            return projectDTO;
        }

        public ProjectDTO MapModelToProjectDTOToUpdate(ProjectInputModelToUpdate model)
        {
            ProjectDTO projectDTO = new ProjectDTO
            {
                ProjectId = model.ProjectId,
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                HtmlCode = model.HtmlCode,
                CssCode = model.CssCode,
                JsCode = model.JsCode,
                CreatedAt = model.CreatedAt,
                TotalTokens = model.TotalTokens,
                TotalMoney = model.TotalMoney
            };

            return projectDTO;
        }
    }
}
