using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab8AuthenticationProgram.Startup))]
namespace Lab8AuthenticationProgram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
