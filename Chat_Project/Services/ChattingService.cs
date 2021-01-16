using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Project.Services
{
    public class ChattingService :ChatService.ChatServiceBase
    {
        private readonly Chatroom _chatroomService;

        public ChattingService(Chatroom chatroomService)
        {
            _chatroomService = chatroomService;
        }
        public override async Task Join(IAsyncStreamReader<Message> requestStream, IServerStreamWriter<Message> responseStream, ServerCallContext context)
        {
            if (!await requestStream.MoveNext()) return;

            do {
                _chatroomService.Join(requestStream.Current.User, responseStream);
                await _chatroomService.BroadcastMessageAsync(requestStream.Current);
            } while (await requestStream.MoveNext());

            _chatroomService.Remove(context.Peer);


        }
    }
}
