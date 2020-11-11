using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChat.Server.Hubs
{
    public class ChatHub : Hub
    {

        //Le static fait la persistance de données (Car lié à Chathub et pas à l'instanciation: commun à tous les chathubs)
        static ConcurrentDictionary<string, string> clientList = new ConcurrentDictionary<string, string>();


        public ChatHub()
        {

            Console.WriteLine("test");
        }
        public async Task SendMessage(string user, string message, string id)
        {
            clientList.TryAdd(id, user);
            await Clients.Client(id).SendAsync("ReceiveMessage", "Nombre de connecté", clientList.Count.ToString());
            await Clients.Client(id).SendAsync("ReceiveMessage", Context.ConnectionId, id);      
            await Clients.All.SendAsync("ReceiveMessage", user, message);

        }
    }
}