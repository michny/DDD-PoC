using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DDD.CommercePoC.Web.Startup))]
namespace DDD.CommercePoC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();

            //app.UseErrorPage(ErrorPageOptions.ShowAll);
        }
    }
}
