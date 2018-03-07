using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OverviewMVCProject.Startup))]
namespace OverviewMVCProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
