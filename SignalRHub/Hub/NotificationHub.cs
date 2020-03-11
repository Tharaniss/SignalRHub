using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub.Hub
{
    public interface INotificationHub
    {
        // here place some method(s) for message from server to client
        //Task SendNoticeEventToClient(string message);
        Task BroadcastMessage(string user, string message);
        Task BroadcastMessage(string message);
    }

    public class NotificationHub : Hub<INotificationHub>
    {
        // here place some method(s) for message from client to server

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.BroadcastMessage(user, message);
        }

        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.BroadcastMessage(message);
        }
    }    
}
