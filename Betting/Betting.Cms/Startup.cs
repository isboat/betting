using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Betting.Cms.Startup))]
namespace Betting.Cms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
