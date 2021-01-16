using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Project
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
        public override Task<HelloReply2> SayHello2(HelloRequest request, ServerCallContext context)
        {
            HelloReply2 reply = new HelloReply2();
            reply.Replies.Add(new HelloReply { Message = "Hello " + request.Name + " How is it going?" });
            reply.Replies.Add(new HelloReply { Message = "Hi " + request.Name + " How are you?" });
            reply.Replies.Add(new HelloReply { Message = "HIII " + request.Name + "What'up?" });

            return Task.FromResult(reply);
        }
    }
}
