using System;
using Domain;

namespace BusinessLogic
{
    public class SimpleReportSender : IReportSender
    {

        public void Send(Report report)
        {
            Console.WriteLine("Send something...");
        }
    }
}