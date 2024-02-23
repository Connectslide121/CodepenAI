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

        public UsersController(IUsersService userService)
        {
            _usersService = userService;
        }

        [HttpGet("{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"THIS IS THE EMAIL: {email}");
            Console.ResetColor();

            UserDTO user = _usersService.GetUserByEmail(email);
            return user == null ? NotFound() : Ok(user);
        }
    }
}
