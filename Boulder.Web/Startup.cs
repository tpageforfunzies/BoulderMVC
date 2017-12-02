using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Boulder.Web.Startup))]
namespace Boulder.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
