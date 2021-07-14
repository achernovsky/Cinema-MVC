using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cinema_MVC.Startup))]
namespace Cinema_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
