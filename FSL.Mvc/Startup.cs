using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FSL.Mvc.Startup))]
namespace FSL.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
