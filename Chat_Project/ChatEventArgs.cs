using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Project
{
    public class ChatEventArgs
    {
        public delegate void ReceivedDate();
        public event ReceivedDate OnCount;

        public void startCounter()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + ":noing Happend");
                if (i == 5)
                {
                    OnCount?.Invoke();
                }
            }
        }
    }
}
