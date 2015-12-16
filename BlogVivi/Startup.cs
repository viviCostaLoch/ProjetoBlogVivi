using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogVivi.Startup))]
namespace BlogVivi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
