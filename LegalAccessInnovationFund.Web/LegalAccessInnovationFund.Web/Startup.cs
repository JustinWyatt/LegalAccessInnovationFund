using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LegalAccessInnovationFund.Web.Startup))]
namespace LegalAccessInnovationFund.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
