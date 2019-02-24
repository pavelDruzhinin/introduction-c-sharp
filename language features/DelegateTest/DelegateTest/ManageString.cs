using System;
using System.Linq;

namespace DelegateTest
{
    public class ManageString
    {
        private const string replaceText = "Замена пробелов на дефис";
        private const string removeText = "Удаление пробелов в строке";
        private const string reverseText = "Переворачиваем строку";

        public static void ReplaceSpaces(ref string s)
        {
            Console.WriteLine(replaceText);
            s = s.Replace(' ', '-');
        }

        public static void RemoveSpaces(ref string s)
        {
            Console.WriteLine(removeText);
            s = s.Replace(" ", string.Empty);
        }

        public static void Reverse(ref string s)
        {
            Console.WriteLine(reverseText);
            s = s.Reverse().Aggregate("", (current, t) => current + t);
        }
    }
}