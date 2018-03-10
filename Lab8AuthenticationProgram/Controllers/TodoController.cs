using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab8AuthenticationProgram.Data;
using Lab8AuthenticationProgram.Data.Entities;

using Lab8AuthenticationProgram.Models;

namespace Lab8AuthenticationProgram.Controllers
{
    public class TodoController : Controller
    {
        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            var Todos = GetTodosForUser(userId);

            return View(Todos);
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(TodoViewModel newTodoViewModel)
        {
            if (ModelState.IsValid)
            {
                Save(newTodoViewModel);
                return RedirectToAction("List", new { userId = newTodoViewModel.UserId });
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            var Todo = MapToTodoViewModel(GetTodo(id));
            return View(Todo);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Todo = MapToTodoViewModel(GetTodo(id));

            return View(Todo);
        }

        [HttpPost]
        public ActionResult Edit(TodoViewModel newTodoViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateTodo(newTodoViewModel);

                return RedirectToAction("List", new { userId = newTodoViewModel.UserId });
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var Todo = GetTodo(id);

            DeleteTodo(id);

            return RedirectToAction("List", new { UserId = Todo.UserId });
        }

        private Todo GetTodo(int TodoId)
        {
            var dbContext = new AppDataContext();

            return dbContext.UserTodo.Find(TodoId);
        }

        private ICollection<TodoViewModel> GetTodosForUser(int userId)
        {
            var TodoViewModels = new List<TodoViewModel>();

            var dbContext = new AppDataContext();

            var Todos = dbContext.UserTodo.Where(Todo => Todo.UserId == userId).ToList();

            foreach (var todo in Todos)
            {
                var newTodoViewModel = MapToTodoViewModel(todo);
                TodoViewModels.Add(newTodoViewModel);
            }

            return TodoViewModels;
        }

        private void Save(TodoViewModel TodoViewModel)
        {
            var dbContext = new AppDataContext();

            var Todo = MapToTodo(TodoViewModel);

            dbContext.UserTodo.Add(Todo);

            dbContext.SaveChanges();
        }

        private void DeleteTodo(int id)
        {
            var dbContext = new AppDataContext();

            var todo = dbContext.UserTodo.Find(id);

            if (todo != null)
            {
                dbContext.UserTodo.Remove(todo);
                dbContext.SaveChanges();
            }
        }

        private void UpdateTodo(TodoViewModel todoViewModel)
        {
            var dbContext = new AppDataContext();
            var todo = dbContext.UserTodo.Find(todoViewModel.Id);
            CopyToTodo(todoViewModel, todo);
            dbContext.SaveChanges();
        }

        private Todo MapToTodo(TodoViewModel newTodoViewModel)
        {
            return new Todo
            {
                Id = newTodoViewModel.Id,
                Subject = newTodoViewModel.Subject,
                Details = newTodoViewModel.Details,
                NextReminder = newTodoViewModel.NextReminder,
                Finished = newTodoViewModel.Finished,
                UserId = newTodoViewModel.UserId
            };
        }

        private TodoViewModel MapToTodoViewModel(Todo mappedTodo)
        {
            return new TodoViewModel
            {
                Id = mappedTodo.Id,
                Subject = mappedTodo.Subject,
                Details = mappedTodo.Details,
                NextReminder = mappedTodo.NextReminder,
                Finished = mappedTodo.Finished,
                UserId = mappedTodo.UserId
            };
        }
        private void CopyToTodo(TodoViewModel todoViewModel, Todo todo)
        {
            todo.Subject = todoViewModel.Subject;
            todo.Details = todoViewModel.Details;
            todo.NextReminder = todoViewModel.NextReminder;
            todo.Finished = todoViewModel.Finished;
           }
    }
}