using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleOwinHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<StartUp>("http://+:8080"))
            {
                Console.ReadKey();
            }

            
        }
    }
}
