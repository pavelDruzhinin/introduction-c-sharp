using Moq;
using ReporterProgram.Classes;
using ReporterProgram.Interfaces;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class ReporterTests
    {
        [TestMethod]
        public void IfNotReportsThenThrowException()
        {
            var builder = new Mock<IReportBuilder>();
            builder.Setup(m => m.CreateReports()).Returns(new List<Report>());

            var sender = new Mock<IReportSender>();

            var reporter = new Reporter(builder.Object, sender.Object);

            Xunit.Assert.Throws<NoReportsException>(() => reporter.SendReports());
        }
    }
}
