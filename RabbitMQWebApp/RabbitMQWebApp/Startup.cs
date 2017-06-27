using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RabbitMQWebApp.Startup))]
namespace RabbitMQWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
