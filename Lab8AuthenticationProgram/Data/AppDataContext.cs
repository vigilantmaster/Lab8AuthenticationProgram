using System.Data.Entity;
using Lab8AuthenticationProgram.Data.Entities;

namespace Lab8AuthenticationProgram.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        //public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Todo> UserTodo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDataContext>
        {
            // intentionally left blank this drops the database everytime
        }
    }
}