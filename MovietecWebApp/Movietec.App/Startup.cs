using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movietec.App.Startup))]
namespace Movietec.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
