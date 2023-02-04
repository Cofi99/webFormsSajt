using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IzradaWebFormsSajta.Startup))]
namespace IzradaWebFormsSajta
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
