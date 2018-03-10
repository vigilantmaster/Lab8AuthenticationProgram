using System.Collections.Generic;
using Lab8AuthenticationProgram.Data.Entities;

namespace Lab8AuthenticationProgram.Data
{
    public class InMemoryDatabase
    {
        //public static List<User> Users = new List<User>();
        public static List<Todo> UserTodos = new List<Todo>();
        public static int id = 0;

        public static int NextId()
        {
            return id++;
        }

        //public static void DeleteUser(int id)
        //{
        //    var user = Users.Find(u => u.Id == id);
        //    Users.Remove(user);
        //}
    }
}