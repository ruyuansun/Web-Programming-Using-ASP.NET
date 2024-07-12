using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RS2237A4.Startup))]
namespace RS2237A4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
