using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KadrovoeAgentstvo.Startup))]
namespace KadrovoeAgentstvo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
