using System;

namespace ReporterProgram.Classes
{
    public class NoReportsException : Exception
    {
        private readonly string _message;
        public string Message { get { return _message; } }

        public NoReportsException()
        {
            _message = "Нет сообщений для отправки.";
        }
    }
}
