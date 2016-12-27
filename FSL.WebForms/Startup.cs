using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FSL.WebForms.Startup))]
namespace FSL.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
