using System;
using BusinessLogic;
using Ninject;
using Ninject.Modules;

namespace ConsoleApplication
{
    class Program
    {
        static void Main()
        {
            IKernel kernel = new StandardKernel(new InlineModule());

            var reporter = kernel.Get<Reporter>();
            var reportCount = reporter.SendReports();

            Console.WriteLine(reportCount);
        }
    }

    internal class InlineModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReportBuilder>().To<SimpleReportBuilder>();
            this.Bind<IReportSender>().To<SimpleReportSender>();
            this.Bind<Reporter>().ToSelf();
        }
    }
}
