using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRTest.Startup))]

namespace SignalRTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Before v2
            //RouteTable.Routes.MapHubs();

            app.MapSignalR();
        } 
    }
}