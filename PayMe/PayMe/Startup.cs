using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PayMe.Startup))]
namespace PayMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
