using Core;
using DataBaseConnection;
using Microsoft.EntityFrameworkCore;
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
    public class UsersService : IUsersService
    {
        private readonly DataContext _dataContext;
        private UsersServiceMappers _mappers;

        public UsersService(DataContext dataContext)
        {
            _dataContext = dataContext;
            _mappers = new UsersServiceMappers();
        }

        public void AddUser(UserDTO userDTOToAdd)
        {
            _dataContext.Users.Add(_mappers.MapUserDTOToUser(userDTOToAdd));
            _dataContext.SaveChanges();
        }

        public UserDTO GetUserById(int userId)
        {
            User? user = _dataContext.Users
                .Where(u => u.UserId == userId)
                .Include(u => u.Projects)
                .FirstOrDefault();

            return _mappers.MapUserToUserDTO(user);
        }

        public bool UpdateUser(UserDTO userDTOToUpdate)
        {
            User newUser = _mappers.MapUserDTOToUser(userDTOToUpdate);
            User? existingUser = _dataContext.Users.Find(userDTOToUpdate.UserId);
            bool userExists = false;

            if (existingUser != null)
            {
                _dataContext.Entry(existingUser).CurrentValues.SetValues(newUser);
                _dataContext.SaveChanges();
                userExists = true;
            }

            return userExists;
        }

        public bool RemoveUser(int userId)
        {
            var userToDelete = _dataContext.Users.Find(userId);
            bool userExists = false;

            if (userToDelete != null)
            {
                _dataContext.Users.Remove(userToDelete);
                _dataContext.SaveChanges();
                userExists = true;
            }

            return userExists;
        }

    }
}
