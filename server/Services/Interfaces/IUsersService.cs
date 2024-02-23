using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUsersService
    {
        void AddUser(UserDTO user);
        UserDTO GetUserById(string userId);
        bool UpdateUser(UserDTO user);
        bool RemoveUser(string userId);
        UserDTO GetUserByEmail(string email);
    }
}
