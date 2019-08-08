using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_biblioteka.Startup))]
namespace E_biblioteka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
