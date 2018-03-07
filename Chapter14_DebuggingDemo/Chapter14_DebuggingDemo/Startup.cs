using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chapter14_DebuggingDemo.Startup))]
namespace Chapter14_DebuggingDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
