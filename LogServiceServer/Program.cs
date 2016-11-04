using LogServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServiceServer
{
    class Program
    {
        static void Main(string[] args)
        {
            LogServer server = new LogServer();
            server.Run();
        }
    }
}
