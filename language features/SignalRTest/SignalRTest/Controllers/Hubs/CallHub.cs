using Microsoft.AspNet.SignalR;

namespace SignalRTest.Controllers.Hubs
{
    public class CallHub:Hub
    {
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<CallHub>();
            context.Clients.All.displayStatus();
        }
    }
}