using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NLayer.WEB.Startup))]
namespace NLayer.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
