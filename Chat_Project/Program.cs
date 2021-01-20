using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ChatEventArgs tester = new ChatEventArgs();

            tester.OnCount += new SenderName().Message;
            tester.OnCount += delegate
            {
                Console.WriteLine("First message was sended");
            };
            tester.OnCount += () =>
            {
                Console.WriteLine("Second message was sended");
            };
            tester.startCounter();
    
            CreateHostBuilder(args).Build().Run();

            Counter c = new Counter(new Random().Next(5));
            c.ThresholdReached += c_ThresholdReached;
            Console.WriteLine("Press 'a' add message");
            while (Console.ReadKey(true).KeyChar=='a')
            {
                Console.WriteLine("adding message");
                c.Add(1);
            }
        }

        private static void c_ThresholdReached(object sender, ChatEventHandler e)
        {
            Console.WriteLine("The sender: {0} was sended at {1} ", e.SenderName, e.ReceivedDate);
            Environment.Exit(0);
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });





    }
}
