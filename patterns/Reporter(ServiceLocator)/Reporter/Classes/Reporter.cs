using ReporterProgram.Interfaces;
using System.Collections.Generic;

namespace ReporterProgram.Classes
{
    public class Reporter : IReporter
    {
        private readonly IReportBuilder _reportBuilder;
        private readonly IReportSender _reportSender;

        public Reporter(IReportBuilder rb, IReportSender rs)
        {
            this._reportBuilder = rb;
            this._reportSender = rs;
        }

        public void SendReports()
        {
            IList<Report> reports = _reportBuilder.CreateReports();

            if (reports.Count == 0)
                throw new NoReportsException();

            foreach (var report in reports)
            {
                _reportSender.Send(report);
            }
        }
    }
}
