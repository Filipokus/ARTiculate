using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        //string x;
        //public Task Join (string group)
        //{
        //    x = group;
        //    return Groups.AddToGroupAsync(Context.ConnectionId, group);
        //}
        public async Task Connect(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendMessage(string user, string message, string group)

        {
            
            await Clients.Group(group).SendAsync("ReceiveMessage", user, message);
        }

      
    }
}
