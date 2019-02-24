using System;
using System.Linq;
using System.Threading.Tasks;

namespace TasksTesting
{
    class Program
    {
        static void Main()
        {
            // Return a value type with a lambda expression
            var task1 = Task<int>.Factory.StartNew(() => 1);
            var i = task1.Result;

            // Return a named reference type with a multi-line statement lambda.
            var task2 = Task<Test>.Factory.StartNew(() =>
            {
                const string s = ".NET";
                const double d = 4.0;
                return new Test { Name = s, Number = d };
            });
            var test = task2.Result;

            

            // Return an array produced by a PLINQ query
            var task3 = Task<string[]>.Factory.StartNew(() =>
            {
                const string path = @"C:\Users\Pavel\Pictures";
                string[] files = System.IO.Directory.GetFiles(path);

                var result = (from file in files.AsParallel()
                              let info = new System.IO.FileInfo(file)
                              where info.Extension == ".jpg"
                              select file).ToArray();

                return result;
            });

            foreach (var name in task3.Result)
                Console.WriteLine(name);

        }
        class Test
        {
            public string Name { get; set; }
            public double Number { get; set; }

        }
    }
}
