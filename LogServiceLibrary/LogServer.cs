using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServiceLibrary
{
    public class LogServer
    {
        private Utility.WebUtility.BroadcastListener broadcastListener;

        private uint ServerSessionKey { get; set; }

        public LogServer()
        {
            this.broadcastListener = new Utility.WebUtility.BroadcastListener();
            this.broadcastListener.BroadcastReceived += this.BroadcastReceived;
            this.ServerSessionKey = (uint)string.Format("{0}{1}", DateTime.Now.ToString(), new Random().NextDouble().ToString()).GetHashCode();
        }

        public void Run()
        {
            broadcastListener.Start();
        }

        private void BroadcastReceived(object sender, Utility.WebUtility.BroadcastReceivedEventArgs args)
        {
            Console.WriteLine(args.message);
            Message incomingMessage = Utility.SerializeUtility.DeserializeJsonString<Message>(args.message);
            if (incomingMessage.Type == MessageType.RequestConnection)
            {
                RequestConnectionMessage message = Utility.SerializeUtility.DeserializeJsonString<RequestConnectionMessage>(args.message);
                Console.WriteLine(message.Type);
            }
        }
    }
}
