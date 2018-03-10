using System.Data.Entity;
using Lab8AuthenticationProgram.Data.Entities;

namespace Lab8AuthenticationProgram.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        //public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Todo> UserTodo { get; set; }

        public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDataContext>
        {
            // intentionally left blank this drops the database everytime
        }
    }
}