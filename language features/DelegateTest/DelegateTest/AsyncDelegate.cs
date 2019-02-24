using System;
using System.Threading;

namespace DelegateTest
{
    public class AsyncDelegate
    {
        public static int CountCharacters(string text)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Подсчёт символов в строке '{0}' в потоке с ID = {1}", text, Thread.CurrentThread.ManagedThreadId);
            return text.Length;
        }

        public static int Parse(string text)
        {
            Thread.Sleep(100);
            Console.WriteLine("Парсинг строки '{0}' в потоке с ID = {1}",
               text, Thread.CurrentThread.ManagedThreadId);
            return int.Parse(text);
        }
    }
}