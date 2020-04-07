using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Michael.Startup))]
namespace Michael
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
