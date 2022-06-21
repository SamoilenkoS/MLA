using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IUserRepository
    {
        int Add(UserDto user);
        bool Delete(int id);
        bool Update(UserDto user);
        IEnumerable<UserDto> GetAll();
        UserDto GetById(int id);
    }
}
