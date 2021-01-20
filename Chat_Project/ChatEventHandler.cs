using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Project
{
    public class ChatEventHandler:ChatEventArgs
    {
        public new DateTime ReceivedDate { get; set; }
        public string SenderName { get; set; }
    }
}
