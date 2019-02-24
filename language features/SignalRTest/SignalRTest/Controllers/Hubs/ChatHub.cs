using Microsoft.AspNet.SignalR;

namespace SignalRTest.Controllers.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

    }
}
