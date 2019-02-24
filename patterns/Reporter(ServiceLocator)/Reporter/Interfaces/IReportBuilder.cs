using ReporterProgram.Classes;
using System.Collections.Generic;

namespace ReporterProgram.Interfaces
{
    public interface IReportBuilder
    {
        IList<Report> CreateReports();
    }
}
