using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(realXP.Startup))]
namespace realXP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
