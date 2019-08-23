using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMVCApp.Startup))]
namespace WebMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
