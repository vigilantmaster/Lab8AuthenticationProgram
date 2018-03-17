using System;
using System.Collections.Generic;
using Lab8AuthenticationProgram.Data.Entities;
using Lab8AuthenticationProgram.Models;
using Lab8AuthenticationProgram.Repositories;

namespace Lab8AuthenticationProgram.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository respository)
        {
            _repository = respository;
        }

        public TodoViewModel GetTodo(int id)
        {
            var todo = _repository.GetTodo(id);
            return MapToTodoViewModel(todo);
        }

        public IEnumerable<TodoViewModel> GetTodosForUser(int userId)
        {
            var petViewModels = new List<TodoViewModel>();

            var users = _repository.GetTodosForUser(userId);

            foreach (var todo in users) petViewModels.Add(todo);

            return petViewModels;
        }

        public void SaveTodo(TodoViewModel todoViewModel)
        {
            var todo = MapToTodo(todoViewModel);

            _repository.SaveTodo(todo);
        }

        public void UpdateTodo(TodoViewModel todoViewModel)
        {
            var todo = _repository.GetTodo(todoViewModel.Id);

            CopyToTodo(todoViewModel, todo);

            _repository.UpdateTodo(todoViewModel);
        }

        public void DeleteTodo(int id)
        {
            _repository.DeleteTodo(id);
        }

        private Todo MapToTodo(TodoViewModel todoViewModel)
        {
            return new Todo
            {
                Id = todoViewModel.Id,
                Finished = todoViewModel.Finished,
                Details = todoViewModel.Details,
                NextReminder = todoViewModel.NextReminder,
                Subject = todoViewModel.Subject,
                UserId = todoViewModel.UserId
            };
        }

        private TodoViewModel MapToTodoViewModel(Todo todo)
        {
            var todoViewModel = new TodoViewModel
            {
                Id = todo.Id,
                Finished = todo.Finished,
                Details = todo.Details,
                NextReminder = todo.NextReminder,
                Subject = todo.Subject,
                UserId = todo.UserId
            };
            todoViewModel.ReminderAlert = (todoViewModel.NextReminder - DateTime.Now).Days < 14;
            return todoViewModel;
        }

        private void CopyToTodo(TodoViewModel todoViewModel, Todo todo)
        {
            todo.Id = todoViewModel.Id;
            todo.Finished = todoViewModel.Finished;
            todo.Details = todoViewModel.Details;
            todo.NextReminder = todoViewModel.NextReminder;
            todo.Subject = todoViewModel.Subject;
            todo.UserId = todoViewModel.UserId;
        }
    }
}