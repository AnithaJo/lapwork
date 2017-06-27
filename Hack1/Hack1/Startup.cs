using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hack1.Startup))]
namespace Hack1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
