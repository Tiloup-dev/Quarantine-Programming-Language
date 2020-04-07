using System;
using System.Collections.Generic;
using System.Text;
using lsc;

namespace lsc
{
    class Program
    {
        public static void Main (String[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Failed to create an QLC console: NO_ARGUMENT");
                Console.ReadKey();
                Environment.Exit(-1);
            }
            string path = args[0];
            if(System.IO.File.Exists(path))
            {
                Parser.Parse(path);
            }
            else
            {
                Console.WriteLine("Failed to create an QLC console: INVALID PATH");
            }
        }
    }
}
