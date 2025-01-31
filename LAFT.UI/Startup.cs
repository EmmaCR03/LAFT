using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAFT.Startup))]
namespace LAFT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
