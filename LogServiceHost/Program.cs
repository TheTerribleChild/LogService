using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            LogServiceHost host = new LogServiceHost();
            host.Run();
        }
    }
}
