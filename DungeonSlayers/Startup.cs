using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DungeonSlayers.Startup))]
namespace DungeonSlayers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
