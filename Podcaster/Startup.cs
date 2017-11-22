using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Podcaster.Startup))]
namespace Podcaster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
