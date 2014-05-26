using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(realxp.Startup))]
namespace realxp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
