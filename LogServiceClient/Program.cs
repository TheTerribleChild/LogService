using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServiceClient
{
    class Options
    {

        [Option('p', "port", Required = true, HelpText = "Specify the port log service is running on.")]
        public int Port { get; set; }

        [Option('x', "exe", Required = true, HelpText = "Specify the application")]
        public string Executable { get; set; }

        [Option('a', "args", Required = false, HelpText = "Specify the arguments for the application in quotes")]
        public string Arguements { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Options options = new Options();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("Port " + options.Port);
                Console.WriteLine("Exe " + options.Executable);
                Console.WriteLine("Args " + options.Arguements);
                LogServiceClient client = new LogServiceClient(options.Port, options.Executable, options.Arguements);
                client.Run();
            }
            else
            {
                Console.WriteLine("Invalid arguement");
            }
        }
    }
}
