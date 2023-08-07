using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Utilities.ExtentReport
{
    public class BaseReport
    {
#pragma warning disable CS8618

        protected ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            string reportPath = "C:\\priya\\Intenship\\Competition Task\\Mars-QACompetition\\MarsCompetitionTask\\MarsCompetitionTask\\Utilities\\ExtentReport\\BaseReport.cs"; // Update this with the desired report path
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void ReportTeardown()
        {
            extent.Flush();
        }
    }
}