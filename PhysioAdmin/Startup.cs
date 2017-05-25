using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhysioAdmin.Startup))]
namespace PhysioAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
