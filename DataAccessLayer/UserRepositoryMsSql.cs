using DataAccessLayer.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class UserRepositoryMsSql : IUserRepository
    {
        public UserRepositoryMsSql()
        {
        }

        public int Add(UserDto user)
        {
            using (var _dbContext = new EFContext(new Microsoft.EntityFrameworkCore.DbContextOptions<EFContext>()))
            {
                _dbContext.Users.Add(user);

                _dbContext.SaveChanges();
            }

            return user.Id;
        }

        public bool Delete(int id)
        {
            bool result;
            using (var _dbContext = new EFContext(new DbContextOptions<EFContext>()))
            {
                var user = new UserDto { Id = id };
                _dbContext.Users.Attach(user);

                _dbContext.Users.Remove(user);
                result = _dbContext.SaveChanges() != 0;
            }

            return result;
        }

        public IEnumerable<UserDto> GetAll()
        {
            IEnumerable<UserDto> result;
            using (var _dbContext = new EFContext(new DbContextOptions<EFContext>()))
            {
                result = _dbContext.Users.ToList();
            }

            return result;
        }

        public UserDto GetById(int id)
        {
            UserDto result;
            using (var _dbContext = new EFContext(new DbContextOptions<EFContext>()))
            {
                result = _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            }

            return result;
        }

        public bool Update(UserDto user)
        {
            bool result;
            using (var _dbContext = new EFContext(new DbContextOptions<EFContext>()))
            {
                _dbContext.Users.Attach(user);

                _dbContext.Entry(user).State = EntityState.Modified;

                result = _dbContext.SaveChanges() != 0;
            }

            return result;
        }
    }
}
