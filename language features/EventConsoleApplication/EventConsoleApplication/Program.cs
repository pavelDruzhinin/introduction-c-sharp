using System;
using EventConsoleApplication.Services;

namespace EventConsoleApplication
{
    class Program
    {
        [STAThread]
        static void Main()
        {

            var catService = new CatService("Toddy", "Kon");

            catService.Run();
            Console.ReadLine();
        }
    }
}
