using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiabetesApp.Startup))]
namespace DiabetesApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
