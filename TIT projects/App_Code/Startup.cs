using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TIT_projects.Startup))]
namespace TIT_projects
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
