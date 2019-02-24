using Ninject.Modules;
using ReporterProgram.Classes;
using ReporterProgram.Interfaces;

namespace ReporterProgram.Modules
{
    class InlineModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReportBuilder>().To<ReportBuilder>();
            this.Bind<IReportSender>().To<SmsReportSender>();

            this.Bind<Reporter>().ToSelf();
        }
    }
}
