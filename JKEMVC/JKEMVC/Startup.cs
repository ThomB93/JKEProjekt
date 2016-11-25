using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JKEMVC.Startup))]
namespace JKEMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
