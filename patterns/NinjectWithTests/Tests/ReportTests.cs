using System.Collections.Generic;
using BusinessLogic;
using Domain;
using Moq;
using Xunit;

namespace Tests
{
    public class ReportTests
    {
        private readonly Mock<IReportBuilder> _reportBuilder;
        private readonly Mock<IReportSender> _reportSender;
        private readonly Reporter _reporter;

        public ReportTests()
        {
            _reportBuilder = new Mock<IReportBuilder>();
            _reportSender = new Mock<IReportSender>();
            _reporter = new Reporter(_reportBuilder.Object, _reportSender.Object);
        }

        [Fact]
        public void ReturnNumberOfSentReports()
        {
            _reportBuilder.Setup(m => m.CreateReports())
                .Returns(new List<Report> { new Report(), new Report() });

            var reportCount = _reporter.SendReports();
            Assert.Equal(2, reportCount);
        }

        [Fact]
        public void SendAllReports()
        {
            _reportBuilder.Setup(m => m.CreateReports()).Returns(new List<Report> { new Report(), new Report() });
            _reporter.SendReports();
            _reportSender.Verify(m => m.Send(It.IsAny<Report>()), Times.Exactly(2));
        }

        [Fact]
        public void SendSpecialReportToAdministratorIfNoReportsCreated()
        {
            _reportBuilder.Setup(m => m.CreateReports()).Returns(new List<Report>());
            _reportBuilder.Setup(m => m.CreateSpecialReport()).Returns(new SpecialReport());
            _reporter.SendReports();

            _reportSender.Verify(m => m.Send(It.IsAny<SpecialReport>()), Times.Once());
        }
    }
}
