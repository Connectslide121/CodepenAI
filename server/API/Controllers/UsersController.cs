using API.InputModels;
using API.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private UserControllerMappers _mappers;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
            _mappers = new UserControllerMappers();
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            UserDTO userById = _usersService.GetUserById(userId);
            return userById == null ? NotFound() : Ok(userById);
        }

        [HttpPost("create")]

        public void CreateUser([FromBody] UserInputModel userInputModel) 
        {
            UserDTO userDTO = _mappers.MapToUserDTO(userInputModel.UserName, userInputModel.Password, userInputModel.Email);
            _usersService.AddUser(userDTO);
        }

        [HttpPut("update")]
        public IActionResult UpdateUser(UserDTO updatedUser)
        {
            bool userUpdated = _usersService.UpdateUser(updatedUser);

            return userUpdated == false ? NotFound() : Ok(updatedUser);
        }

        [HttpDelete("delete/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            bool userDeleted = _usersService.RemoveUser(userId);

            return userDeleted == false ? NotFound() : Ok(userId);
        }


    }
}
