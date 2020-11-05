using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouStreet.Data.Models;

namespace YouStreet.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string message, string to)
        {
            var userName = Context.User.Identity.Name;

            if (Context.UserIdentifier != to) // если получатель и текущий пользователь не совпадают
                await Clients.User(Context.UserIdentifier).SendAsync("Receive", message, userName);
            await Clients.User(to).SendAsync("Receive", message, userName);
        }
    }
}
