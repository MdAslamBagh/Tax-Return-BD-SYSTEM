using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tax_Return_BD_System.Startup))]
namespace Tax_Return_BD_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
