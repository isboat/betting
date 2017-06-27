using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Betting.Web.Startup))]
namespace Betting.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
