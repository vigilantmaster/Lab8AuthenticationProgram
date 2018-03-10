using System.Collections.Generic;
using System.Web.Mvc;
using Lab8AuthenticationProgram.Data;

using Lab8AuthenticationProgram.Data.Entities;
using Lab8AuthenticationProgram.Models;
using Lab8AuthenticationProgram.Services;

namespace Lab8AuthenticationProgram.Controllers
{
   
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        //public UserController(IUserRepository userRepository)  without dependency injection set up this doesn't work
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel newUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = newUserViewModel;
                _userService.SaveUser(user);
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }
        public ActionResult List()
        {
            var users = GetAllUsers();
           
            return View(users);
        }

        public ActionResult Details(int id)
        {
            var user = _userService.GetUser(id);
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _userService.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(userViewModel);
                return RedirectToAction("List");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("List");
        }

        private UserViewModel GetUser(int id)
        {
            var user = _userService.GetUser(id);
            return user;
        }

        private IEnumerable<UserViewModel> GetAllUsers()
        {
            var userViewModels = new List<UserViewModel>();
            var Users = _userService.GetAllUsers();
            foreach (var user in Users)
            {
                var userViewModel = user;
                userViewModels.Add(userViewModel);
            }
            return userViewModels;
        }

        private void SaveUser(User user)
        {
            var dbContext = new AppDataContext();
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        private void UpdateUser(UserViewModel userViewModel)
        {
            var dbContext = new AppDataContext();
            var user = dbContext.Users.Find(userViewModel.Id);
            CopyToUser(userViewModel, user);
            dbContext.SaveChanges();
        }

        private void DeleteUser(int id)
        {
            var dbContext = new AppDataContext();
            var user = dbContext.Users.Find(id);
            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        private User MapToUser(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                EmailAddress = userViewModel.EmailAddress,
                DOB = userViewModel.DOB,
                YearsInSchool = userViewModel.YearsInSchool
            };
        }

        private UserViewModel MapToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                DOB = user.DOB,
                YearsInSchool = user.YearsInSchool
            };
        }

      
        private void CopyToUser(UserViewModel userViewModel, User user)
        {
            user.FirstName = userViewModel.FirstName;
            user.MiddleName = userViewModel.MiddleName;
            user.LastName = userViewModel.LastName;
            user.EmailAddress = userViewModel.EmailAddress;
            user.DOB = userViewModel.DOB;
            user.YearsInSchool = userViewModel.YearsInSchool;
        }
    }
}