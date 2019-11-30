using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SlvTeam.Domain.Entities;

namespace SlvTeam.WebUI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserManager<SlvTeamUser> _manager;
        public ChatHub(UserManager<SlvTeamUser> manager)
        {
            _manager = manager;
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
