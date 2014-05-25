using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(individueleOpdracht.Startup))]
namespace individueleOpdracht
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
