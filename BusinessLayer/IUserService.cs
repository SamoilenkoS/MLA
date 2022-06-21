using BusinessLayer.Models;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IUserService
    {
        int RegisterUser(UserToRegister user);
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
    }
}
