using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BackboneView.Startup))]
namespace BackboneView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
