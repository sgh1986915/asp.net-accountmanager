using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AccountManager.Startup))]
namespace AccountManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
