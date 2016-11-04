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


        private static readonly int MAX_CONNECTION_ATTEMPT = 3;

        public LogClient(int logServerPort, string applicationName)
        {
            this.LogServerBroadcastPort = logServerPort;
            this.ApplicationName = applicationName;
            
        }

        private void EstablishConnectionToLogServer()
        {
            for(int attemptNum = 0; attemptNum < MAX_CONNECTION_ATTEMPT; attemptNum++)
            {
                uint clientSessionKey = (uint)string.Format("{0}{1}{2}", DateTime.Now.ToString(), new Random().NextDouble().ToString(), this.ApplicationName).GetHashCode();
                RequestConnectionMessage request = new RequestConnectionMessage(ApplicationName, clientSessionKey);

                Utility.WebUtility.BroadcastMessage(LogServerBroadcastPort, Utility.SerializeUtility.SerializeToJsonString(request));
                Console.WriteLine(Utility.SerializeUtility.SerializeToJsonString(request));
            }

            
            //Message m = (Message)Utility.SerializeUtility.DeserializeJsonString(Utility.SerializeUtility.SerializeToJsonString(request));
        }

        public void Run()
        {
            EstablishConnectionToLogServer();
        }
    }
}
