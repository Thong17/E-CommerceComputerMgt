using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECommerceComMgt.Startup))]
namespace ECommerceComMgt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
