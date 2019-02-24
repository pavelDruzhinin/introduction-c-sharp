using Microsoft.AspNet.SignalR;

namespace SignalRTest.Controllers.Hubs
{
    public class JobHub : Hub
    {
        //
        // GET: /JobHub/

        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<JobHub>();
            context.Clients.All.displayStatus();
        }
    }
}
