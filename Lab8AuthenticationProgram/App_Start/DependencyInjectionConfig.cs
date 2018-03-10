using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using Lab8AuthenticationProgram.Data;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

using Lab8AuthenticationProgram.Repositories;
using Lab8AuthenticationProgram.Services;

namespace Lab8AuthenticationProgram
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            //container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<ITodoRepository, TodoRepository>(Lifestyle.Scoped);
            //container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<ITodoService, TodoService>(Lifestyle.Scoped);
            container.Register<AppDataContext, AppDataContext>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}