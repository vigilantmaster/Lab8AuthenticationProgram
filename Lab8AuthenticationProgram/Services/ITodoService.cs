using System.Collections.Generic;
using Lab8AuthenticationProgram.Models;

namespace Lab8AuthenticationProgram.Services
{
    public interface ITodoService
    {
        TodoViewModel GetTodo(int id);

        IEnumerable<TodoViewModel> GetTodosForUser(int userId);

        void SaveTodo(TodoViewModel todo);

        void UpdateTodo(TodoViewModel user);

        void DeleteTodo(int id);
    }
}