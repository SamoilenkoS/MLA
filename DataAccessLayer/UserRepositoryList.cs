using DataAccessLayer.DTO;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class UserRepositoryList : IUserRepository
    {
        private static int CurrentId;
        private static List<UserDto> _users;

        static UserRepositoryList()
        {
            CurrentId = 1;
            _users = new List<UserDto>();
        }

        public int Add(UserDto user)
        {
            user.Id = CurrentId++;
            _users.Add(user);

            return CurrentId - 1;
        }

        public bool Delete(int id)
        {
            return _users.Remove(_users.Find(x => x.Id == id));
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _users;
        }

        public UserDto GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(UserDto user)
        {
            var userInList = _users.Find(x => x.Id == user.Id);
            var itsIndex = _users.IndexOf(userInList);
            if(itsIndex != -1)
            {
                _users[itsIndex] = user;
            }

            return itsIndex != -1;
        }
    }
}
