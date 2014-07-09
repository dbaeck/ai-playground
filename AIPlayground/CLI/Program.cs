using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AIPlayground.Search.Algorithm;
using Common;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Insert Problem here!

            using (new OperationMonitor("sender", "sleep",time)) 
            {
               
             

            }
            Console.In.Read();

        }

        private static void time(string result)
        {
            Console.Out.WriteLine(result);
        }
    }
}
