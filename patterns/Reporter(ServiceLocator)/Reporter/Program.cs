using Ninject;
using ReporterProgram.Classes;
using ReporterProgram.Modules;

namespace ReporterProgram
{
    class Program
    {
        static void Main()
        {
            IKernel kernel = new StandardKernel(new InlineModule());

            var reporter = kernel.Get<Reporter>();
            reporter.SendReports();
        }
    }
}
