using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rentflix.Startup))]
namespace Rentflix
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
