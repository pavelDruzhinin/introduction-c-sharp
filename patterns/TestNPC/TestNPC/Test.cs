using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestNPC
{
    public static class Test
    {
        private static readonly List<string> _list = CreateList();

        private const int RunCount = 5;
        private const int IterationCount = 10;
        private const int ValueCount = 10000;


        private static List<string> CreateList()
        {
            var random = new Random();
            var result = new List<string>();
            for (var i = 0; i <= ValueCount; i++)
                result.Add("item " + random.Next());

            return result;
        }

        private static double _divider;

        public static void RunManualNPC()
        {
            var x = new ManualNPC();

            var list = _list;

            var swatch = Stopwatch.StartNew();

            for (var run = 0; run < RunCount; run++)
            {
                for (var n = 0; n <= IterationCount; n++)
                    for (int i = 0, c = list.Count; i < c; i++)
                        x.MyProperty = list[i];

                for (int i = 0, c = list.Count; i < c; i++)
                    for (var n = 0; n <= IterationCount; n++)
                        x.MyProperty = list[i];

                for (var n = 0; n <= IterationCount; n++)
                    for (int i = 0, c = list.Count; i < c; i++)
                        x.MyProperty2 = list[i];

                for (int i = 0, c = list.Count; i < c; i++)
                    for (var n = 0; n <= IterationCount; n++)
                        x.MyProperty2 = list[i];
            }

            swatch.Stop();

            _divider = swatch.ElapsedMilliseconds;

            Console.WriteLine("Manual NPC: {0} ms, Factor: {1:0.00}", swatch.ElapsedMilliseconds,
                swatch.ElapsedMilliseconds / _divider);
        }

        internal static void RunMagicNPC()
        {
            var x = new MagicNPC();

            var list = _list;

            var swatch = Stopwatch.StartNew();

            for (var run = 0; run < RunCount; run++)
            {
                for (var n = 0; n <= IterationCount; n++)
                    for (int i = 0, c = list.Count; i < c; i++)
                        x.MyProperty = list[i];

                for (int i = 0, c = list.Count; i < c; i++)
                    for (var n = 0; n <= IterationCount; n++)
                        x.MyProperty = list[i];

                for (var n = 0; n <= IterationCount; n++)
                    for (int i = 0, c = list.Count; i < c; i++)
                        x.MyProperty2 = list[i];

                for (int i = 0, c = list.Count; i < c; i++)
                    for (var n = 0; n <= IterationCount; n++)
                        x.MyProperty2 = list[i];
            }

            swatch.Stop();

            Console.WriteLine("Magic NPC: {0} ms, Factor: {1:0.00}", swatch.ElapsedMilliseconds,
                swatch.ElapsedMilliseconds / _divider);
        }


        internal static void RunStackTraceNPC()
        {
            var x = new StackTraceNPC();

            var list = _list;

            var swatch = Stopwatch.StartNew();

            for (var run = 0; run < RunCount; run++)
            {
                for (var n = 0; n <= IterationCount; n++)
                    for (int i = 0, c = list.Count; i < c; i++)
                        x.MyProperty = list[i];

                for (int i = 0, c = list.Count; i < c; i++)
                    for (var n = 0; n <= IterationCount; n++)
                        x.MyProperty = list[i];

                for (var n = 0; n <= IterationCount; n++)
                    for (int i = 0, c = list.Count; i < c; i++)
                        x.MyProperty2 = list[i];

                for (int i = 0, c = list.Count; i < c; i++)
                    for (var n = 0; n <= IterationCount; n++)
                        x.MyProperty2 = list[i];
            }

            swatch.Stop();

            Console.WriteLine("StackTrace NPC: {0} ms, Factor: {1:0.00}", swatch.ElapsedMilliseconds,
                swatch.ElapsedMilliseconds / _divider);
        }

        internal static void RunLambdaNPC()
        {
            var x = new LambdaNPC();

            var list = _list;

            var swatch = Stopwatch.StartNew();

            for (var run = 0; run < RunCount; run++)
            {
                for (var n = 0; n <= IterationCount; n++)
                    for (int i = 0, c = list.Count; i < c; i++)
                        x.MyProperty = list[i];

                for (int i = 0, c = list.Count; i < c; i++)
                    for (var n = 0; n <= IterationCount; n++)
                        x.MyProperty = list[i];

                for (var n = 0; n <= IterationCount; n++)
                    for (int i = 0, c = list.Count; i < c; i++)
                        x.MyProperty2 = list[i];

                for (int i = 0, c = list.Count; i < c; i++)
                    for (var n = 0; n <= IterationCount; n++)
                        x.MyProperty2 = list[i];
            }

            swatch.Stop();

            Console.WriteLine("Lambda NPC: {0} ms, Factor: {1:0.00}", swatch.ElapsedMilliseconds,
                swatch.ElapsedMilliseconds / _divider);
        }
    }
}