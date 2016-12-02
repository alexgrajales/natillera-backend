using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Natillera.Startup))]
namespace Natillera
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
