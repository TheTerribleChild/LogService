using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServiceLibrary
{
    public class LogClient
    {
        public int LogServerBroadcastPort { get; set; }

        public string ApplicationName { get; set; }

        private uint ClientSessionKey { get; set; }
        private uint ServerSessionKey { get; set; }

        public LogClient(int logServerPort, string applicationName)
        {
            this.LogServerBroadcastPort = logServerPort;
            this.ApplicationName = applicationName;
            this.ClientSessionKey = (uint)string.Format("{0}{1}{2}", DateTime.Now.ToString(), new Random().NextDouble().ToString(), this.ApplicationName).GetHashCode();
        }

        private void EstablishConnectionToLogServer()
        {
            RequestConnectionMessage request = new RequestConnectionMessage(ApplicationName, ClientSessionKey);
            Utility.WebUtility.BroadcastMessage(LogServerBroadcastPort, Utility.SerializeUtility.SerializeToJsonString(request));
            Console.WriteLine(Utility.SerializeUtility.SerializeToJsonString(request));
            //Message m = (Message)Utility.SerializeUtility.DeserializeJsonString(Utility.SerializeUtility.SerializeToJsonString(request));
        }

        public void Run()
        {
            EstablishConnectionToLogServer();
        }
    }
}
