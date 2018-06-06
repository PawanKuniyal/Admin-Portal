using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Helpa.Startup))]
namespace Helpa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder MyApp)
        {
            MyApp.MapSignalR();
        }
    }
}
