using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FSL.Mvc.Startup))]
namespace FSL.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
