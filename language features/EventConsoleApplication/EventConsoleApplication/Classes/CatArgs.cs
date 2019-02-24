using System;

namespace EventConsoleApplication.Classes
{
    public class CatArgs : EventArgs
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }


    }
}