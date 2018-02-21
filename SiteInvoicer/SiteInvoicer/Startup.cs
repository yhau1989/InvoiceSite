using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteInvoicer.Startup))]
namespace SiteInvoicer
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
