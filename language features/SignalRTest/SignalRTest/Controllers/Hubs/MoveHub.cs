using Microsoft.AspNet.SignalR;

namespace SignalRTest.Controllers.Hubs
{
    public class MoveHub : Hub
    {
        //
        // GET: /MoveHub/

        public void MoveShape(int x, int y)
        {
            Clients.All.shapeMoved(x, y);
        }

    }
}
