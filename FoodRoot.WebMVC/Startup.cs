using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodRoot.WebMVC.Startup))]
namespace FoodRoot.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
