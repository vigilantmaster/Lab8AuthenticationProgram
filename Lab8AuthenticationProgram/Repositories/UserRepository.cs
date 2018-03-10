using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab8AuthenticationProgram.Data;

using Lab8AuthenticationProgram.Data.Entities;

namespace Lab8AuthenticationProgram.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDataContext _dbContext;
        public UserRepository(AppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUser(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void SaveUser(User user)
        {
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);

            if (user == null) return;

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}