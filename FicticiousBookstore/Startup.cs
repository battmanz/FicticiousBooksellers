using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FicticiousBookstore.Startup))]
namespace FicticiousBookstore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
