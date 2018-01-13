using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace DotNetCore2.App.SignalR
{
    public class CoreHub : Hub<ICoreHub>
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public void Send(string name, string message)
        {
            Clients.All.UserUpdated();
        }
    }
}
