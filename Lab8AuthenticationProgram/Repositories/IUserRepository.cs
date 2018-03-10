using System.Collections.Generic;
using Lab8AuthenticationProgram.Data.Entities;

namespace Lab8AuthenticationProgram.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);

        IEnumerable<User> GetAllUsers();

        void SaveUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);
    }
}