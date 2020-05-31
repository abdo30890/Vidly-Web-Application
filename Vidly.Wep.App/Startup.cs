using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly.Wep.App.Startup))]
namespace Vidly.Wep.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
