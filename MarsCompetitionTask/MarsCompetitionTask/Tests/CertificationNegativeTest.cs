using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using MarsCompetitionTask.Pages;
using MarsCompetitionTask.TestModel;
using MarsCompetitionTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MarsCompetitionTask.Tests
{
    public class CertificationNegativeTest : CommonDriver
    {
#pragma warning disable CS8618

        private ExtentReports extent;
        private ExtentTest test;
        
        [OneTimeSetUp]
        public void SetupReporting()
        {
            string reportPath = "C:\\priya\\Intenship\\Competition Task\\Mars-QACompetition\\MarsCompetitionTask\\MarsCompetitionTask\\Utilities\\ExtentReport\\BaseReport.cs";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }



        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private CertificationNegativePage certificationNegativePageObj = new CertificationNegativePage();
      [SetUp]
        public void SetUpAction()
        {
            // Open Chrome Browser
            driver = new ChromeDriver();
            //Login page object identified and defined
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj.navigateSteps();
            loginTestPageObj.loginSteps();
        }

        [Test, Order(1)]
        public void AddCertificationData_Test()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "AddCertificationNegativeData.json";
            List<CertificationsTestModel> AddCertificationNegativeData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine("Data from JSON file is: " +AddCertificationNegativeData.ToString());
            foreach (var data in AddCertificationNegativeData)
            {
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                // Perform the education test using the Education data
                certificationNegativePageObj.addCertifications(certificate, certifiedFrom, year);
                string screenshotPath = CaptureScreenshot(driver, "AddCertificationNegative");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
        }
        [Test, Order(2)]
        public void UpdateCertificationsData_Test()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "UpdatedCertificationNegativeData.json";
            List<CertificationsTestModel> UpdatedCertificationNegativeData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine("Data from JSON file is: " + UpdatedCertificationNegativeData.ToString());
            foreach (var data in UpdatedCertificationNegativeData)
            {
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                // Perform the education test using the Education data
                certificationNegativePageObj.UpdateCertifications(certificate, certifiedFrom, year);
                string screenshotPath = CaptureScreenshot(driver, "UpdatedCertificationNegative");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }

        }
        public void TearDownAction()
        {
            driver.Quit();
            extent.Flush();
        }
        private string CaptureScreenshot(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            string screenshotPath = Path.Combine(@"C:\priya\Intenship\Competition Task\Mars-QACompetition\MarsCompetitionTask\MarsCompetitionTask\NunitScreenshot\", $"{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png");
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            return screenshotPath;
        }
        [OneTimeTearDown]
        public void ExtentTeardown()
        {
            extent.Flush();
        }
    }
}
