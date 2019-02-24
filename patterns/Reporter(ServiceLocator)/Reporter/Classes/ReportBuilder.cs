using ReporterProgram.Interfaces;
using System.Collections.Generic;

namespace ReporterProgram.Classes
{
    class ReportBuilder : IReportBuilder
    {
        public IList<Report> CreateReports()
        {
            return new List<Report>();
        }
    }
}
