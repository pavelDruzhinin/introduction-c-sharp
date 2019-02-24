using System.Collections.Generic;
using Domain;

namespace BusinessLogic
{
    public class SimpleReportBuilder : IReportBuilder
    {
        public IList<Report> CreateReports()
        {
            return new List<Report>
            {
                new Report(),
                new Report(),
                new Report()
            };
        }

        public SpecialReport CreateSpecialReport()
        {
            return new SpecialReport();
        }
    }
}