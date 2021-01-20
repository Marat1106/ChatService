using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Project
{
    public class Counter
    {
        private readonly int threshold;
        private int total;
        private string senderName;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }
        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                ChatEventHandler handler = new ChatEventHandler()
                {
                    SenderName = senderName,
                    ReceivedDate=DateTime.Now


                };
                OnThresholdReached(handler);
            }
        }

        private void OnThresholdReached(ChatEventHandler handler)
        {
            ThresholdReached?.Invoke(this, handler);
        }
        public event EventHandler <ChatEventHandler> ThresholdReached;
    }
}
