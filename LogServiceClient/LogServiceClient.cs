using LogServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServiceClient
{
    public class LogServiceClient
    {

        public int LogServerBroadcastPort { get; set; }

        public string ExectuableName { get; set; }
        public string ExecutableArgs { get; set; }

        private uint ClientSessionKey { get; set; }
        private uint ServerSessionKey { get; set; }

        public LogServiceClient(int logServerPort, string executableName, string executableArgs)
        {
            this.LogServerBroadcastPort = logServerPort;
            this.ExectuableName = executableName;
            this.ExecutableArgs = executableArgs;
            this.ClientSessionKey = (uint)string.Format("{0}{1}{2}{3}", DateTime.Now.ToString(), new Random().NextDouble().ToString(), this.ExectuableName, this.ExecutableArgs).GetHashCode();
        }

        private void EstablishConnectionToLogServer()
        {
            RequestConnectionMessage request = new RequestConnectionMessage(ExectuableName, ClientSessionKey);
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
