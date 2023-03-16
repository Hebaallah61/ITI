using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(task2.Startup))]
namespace task2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
