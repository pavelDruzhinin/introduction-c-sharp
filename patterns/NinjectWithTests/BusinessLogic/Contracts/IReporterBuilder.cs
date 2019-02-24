using System.Collections.Generic;
using Domain;

namespace BusinessLogic
{
    public interface IReportBuilder
    {
        IList<Report> CreateReports();
        SpecialReport CreateSpecialReport();
    }
}