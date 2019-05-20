using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BitHub.Startup))]
namespace BitHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
