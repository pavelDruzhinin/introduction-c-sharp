using System.Collections.Generic;
using Domain;

namespace BusinessLogic
{
    public class Reporter
    {
        private readonly IReportBuilder _reportBuilder;
        private readonly IReportSender _reportSender;

        public Reporter(IReportBuilder reportBuilder, IReportSender reportSender)
        {
            _reportBuilder = reportBuilder;
            _reportSender = reportSender;
        }

        public int SendReports()
        {
            IList<Report> reports = _reportBuilder.CreateReports();

            if (HasNoReports(reports))
            {
                _reportSender.Send(_reportBuilder.CreateSpecialReport());
            }

            foreach (var report in reports)
            {
                _reportSender.Send(report);
            }
            return reports.Count;
        }

        private static bool HasNoReports(IList<Report> reports)
        {
            return reports.Count == 0;
        }
    }
}
