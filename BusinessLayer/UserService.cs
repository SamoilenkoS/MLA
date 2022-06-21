using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public UserDto GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public int RegisterUser(UserToRegister user)
        {
            return _userRepository.Add(MapUserModelToUserDto(user));
        }

        private UserDto MapUserModelToUserDto(UserToRegister user)
        {
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone
            };
        }
    }
}
