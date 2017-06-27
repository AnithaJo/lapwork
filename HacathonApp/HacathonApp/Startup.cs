using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HacathonApp.Startup))]
namespace HacathonApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
