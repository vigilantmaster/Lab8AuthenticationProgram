using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab8AuthenticationProgram.Models;
using Lab8AuthenticationProgram.Repositories;

namespace Lab8AuthenticationProgram.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _repository.GetUser(id);

            return (user.MapToUserViewModel());
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var userViewModels = new List<UserViewModel>();

            var users = _repository.GetAllUsers();
            foreach (var user in users)
            {
                userViewModels.Add(user.MapToUserViewModel());
            }

            return userViewModels;
        }

        public void SaveUser(UserViewModel userViewModel)
        {
            _repository.SaveUser(userViewModel.MapToUser());
        }

        public void UpdateUser(UserViewModel userViewModel)
        {
            var user = _repository.GetUser(userViewModel.Id);
            

            _repository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _repository.DeleteUser(id);
        }
    }
}