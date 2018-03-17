using System.Collections.Generic;
using Lab8AuthenticationProgram.Data.Entities;
using Lab8AuthenticationProgram.Models;

namespace Lab8AuthenticationProgram.Repositories
{
    public interface ITodoRepository
    {
        Todo GetTodo(int TodoId);
        ICollection<TodoViewModel> GetTodosForUser(int userId);
        void Save(TodoViewModel TodoViewModel);
        void DeleteTodo(int id);
        void UpdateTodo(TodoViewModel todoViewModel);
        void SaveTodo(Todo todo);
    }
}