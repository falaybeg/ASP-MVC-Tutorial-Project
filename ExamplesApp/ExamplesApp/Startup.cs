using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamplesApp.Startup))]
namespace ExamplesApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
