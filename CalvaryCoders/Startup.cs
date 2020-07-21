using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CalvaryCoders.Startup))]
namespace CalvaryCoders
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
