using Services.DTOs;

namespace API.Mappers
{
    public class UserControllerMappers
    {
        public UserDTO MapToUserDTO(string userName, string password, string email)
        {
            UserDTO userDTO = new UserDTO
            {
                UserName = userName,
                Password = password,
                Email = email,
                RegistrationDate = DateTime.Now
            };

            return userDTO;
        }
    }
}
