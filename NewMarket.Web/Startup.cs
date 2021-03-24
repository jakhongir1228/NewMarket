using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewMarket.Web.Startup))]
namespace NewMarket.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
