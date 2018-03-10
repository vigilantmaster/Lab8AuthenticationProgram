using System.Collections.Generic;
using Lab8AuthenticationProgram.Models;

namespace Lab8AuthenticationProgram.Services
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);

        IEnumerable<UserViewModel> GetAllUsers();

        void SaveUser(UserViewModel user);

        void UpdateUser(UserViewModel user);

        void DeleteUser(int id);
  }
}