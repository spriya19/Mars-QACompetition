using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Model;
using System.Diagnostics;

namespace MarsCompetitionTask.Utilities.ExtentReport
{
    public class BaseReportManager : CommonDriver
    {
#pragma warning disable CS8618

        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;

        public static ExtentReports getInstance()
        {
            if (extent == null)
            {
                extent = new ExtentReports();
                htmlReporter = new ExtentHtmlReporter("C:\\priya\\Intenship\\Competition Task\\Mars-QACompetition\\MarsCompetitionTask\\MarsCompetitionTask\\Utilities\\ExtentReport\\BaseReportManager.cs"); // Path to the report file
                extent.AttachReporter(htmlReporter);
            }
            return extent;
        }
    }
}


        