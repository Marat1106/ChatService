using Grpc.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Project
{
    public class Chatroom
    {
        private readonly ConcurrentDictionary<string, IServerStreamWriter<Message>> users = new ConcurrentDictionary<string, IServerStreamWriter<Message>>();
        public void Join(string name, IServerStreamWriter<Message> response) => users.TryAdd(name, response);
        public void Remove(string name) => users.TryRemove(name, out _);
        public async Task BroadcastMessageAsync(Message message) => await BroadcaseMessage(message);
        private async Task BroadcaseMessage(Message message)
        {
            foreach(var user in users.Where(x => x.Key != message.User))
            {
                var item = await SendMessageToSubcriber(user,message);
                if (item != null)
                {
                    Remove(item?.Key);
                }
            }
        }

        private async Task<KeyValuePair<string, IServerStreamWriter<Message>>?> SendMessageToSubcriber(KeyValuePair<string, IServerStreamWriter<Message>> user,Message message)
        {
            try
            {
                await user.Value.WriteAsync(message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return user;
            }
            
            
        }

    }
}
