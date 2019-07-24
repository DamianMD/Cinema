using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StartCinema.Startup))]
namespace StartCinema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
