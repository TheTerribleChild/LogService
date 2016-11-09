using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogServiceLibrary
{
    public class LogServer
    {
        private Utility.WebUtility.UdpConnector udpListener;

        private uint ServerSessionKey { get; set; }

        private uint ConnectionKeyHash { get; set; }

        public LogServer(string connectionPassword = null)
        {
            this.udpListener = new Utility.WebUtility.UdpConnector();
            this.udpListener.MessageReceived += this.MessageReceived;
            this.ServerSessionKey = (uint)string.Format("{0}{1}", DateTime.Now.ToString(), new Random().NextDouble().ToString()).GetHashCode();

            if(connectionPassword == null || connectionPassword.Length == 0)
                connectionPassword = new Random().Next().ToString("X10");

            Console.WriteLine("Connection password: " + connectionPassword);

            this.ConnectionKeyHash = (uint) connectionPassword.GetHashCode();
        }

        public void Run()
        {
            udpListener.Listen = true;
        }

        private void MessageReceived(object sender, Utility.WebUtility.MessageReceivedEventArgs args)
        {
            Console.WriteLine(args.Message);
            Message incomingMessage = Utility.SerializeUtility.DeserializeJsonString<Message>(args.Message);
            if (incomingMessage.Type == MessageType.RequestConnection)
            {
                RequestConnectionMessage message = Utility.SerializeUtility.DeserializeJsonString<RequestConnectionMessage>(args.Message);
                Console.WriteLine(message.Type + " " + args.RemoteEndpoint.Address);
            }
        }
    }
}
