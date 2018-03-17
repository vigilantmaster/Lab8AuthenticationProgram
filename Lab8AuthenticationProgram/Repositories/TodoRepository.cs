using System;
using System.Collections.Generic;
using System.Linq;
using Lab8AuthenticationProgram.Data;
using Lab8AuthenticationProgram.Data.Entities;
using Lab8AuthenticationProgram.Models;

namespace Lab8AuthenticationProgram.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public Todo GetTodo(int TodoId)
        {
            var dbContext = new AppDataContext();

            return dbContext.UserTodo.Find(TodoId);
        }

        public ICollection<TodoViewModel> GetTodosForUser(int userId)
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

        public void SaveTodo(Todo todo)
        {
            var dbContext = new AppDataContext();
            dbContext.UserTodo.Add(todo);
            dbContext.SaveChanges();
        }

        public void Save(TodoViewModel todo)
        {
            SaveTodo(todo);
        }

        public void DeleteTodo(int id)
        {
            var dbContext = new AppDataContext();

            var todo = dbContext.UserTodo.Find(id);

            if (todo != null)
            {
                dbContext.UserTodo.Remove(todo);
                dbContext.SaveChanges();
            }
        }

        public void UpdateTodo(TodoViewModel todoViewModel)
        {
            var dbContext = new AppDataContext();
            var todo = dbContext.UserTodo.Find(todoViewModel.Id);
            CopyToTodo(todoViewModel, todo);
            dbContext.SaveChanges();
        }

        public void SaveTodo(TodoViewModel TodoViewModel)
        {
            var dbContext = new AppDataContext();

            var Todo = MapToTodo(TodoViewModel);

            dbContext.UserTodo.Add(Todo);

            dbContext.SaveChanges();
        }


        private void CopyToTodo(TodoViewModel todoViewModel, Todo todo)
        {
            todo.Subject = todoViewModel.Subject;
            todo.Details = todoViewModel.Details;
            todo.NextReminder = todoViewModel.NextReminder;
            todo.Finished = todoViewModel.Finished;
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
            var todoViewModel = new TodoViewModel
            {
                Id = mappedTodo.Id,
                Finished = mappedTodo.Finished,
                Details = mappedTodo.Details,
                NextReminder = mappedTodo.NextReminder,
                Subject = mappedTodo.Subject,
                UserId = mappedTodo.UserId
            };
            todoViewModel.ReminderAlert = (todoViewModel.NextReminder - DateTime.Now).Days < 14;
            return todoViewModel;
        }
    }
}