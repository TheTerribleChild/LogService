using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogServiceLibrary
{
    public class Session
    {
        public uint ClientSessionKey { get; private set; }
        public uint ServerSessionKey { get; private set; }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public IPEndPoint ClientEndpoint { get; private set; }
        public IPEndPoint ServerEndpoint { get; private set; }

        public bool Active
        {
            get
            {
                return EndTime < StartTime;
            }
        }

        public Session(uint clientSessionKey, uint serverSessionKey, IPEndPoint clientEndpoint, IPEndPoint serverEndpoint)
        {
            this.ClientSessionKey = clientSessionKey;
            this.ServerSessionKey = serverSessionKey;
            this.ClientEndpoint = clientEndpoint;
            this.ServerEndpoint = serverEndpoint;
            this.StartTime = DateTime.Now;
            this.EndTime = DateTime.MinValue;
        }

        public void EndSession()
        {
            this.EndTime = DateTime.Now;
        }
    }
}
