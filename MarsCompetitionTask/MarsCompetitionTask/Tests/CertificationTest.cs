using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using com.sun.org.apache.xml.@internal.resolver.helpers;
using com.sun.tools.javac.tree;
using MarsCompetitionTask.Pages;
using MarsCompetitionTask.TestModel;
using MarsCompetitionTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Tests  
{
    [TestFixture]
    public class CertificationsTest : CommonDriver
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
            //htmlReporter = new ExtentHtmlReporter("TestReport.html");
            extent.AttachReporter(htmlReporter);
        }

        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private CertificationPage CertificationPageObj = new CertificationPage();

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
            string sFile = "AddCertificationPositiveData.json";
            // Read test data from the JSON file using JsonHelper
            List<CertificationsTestModel> AddCertificationPositiveData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine(AddCertificationPositiveData.ToString());
            foreach (var data in AddCertificationPositiveData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                // Perform the education test using the Education data
                CertificationPageObj.addCertifications(certificate, certifiedFrom, year);
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

                string screenshotPath = CaptureScreenshot(driver, "AddCertification");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

                string newCertificate = CertificationPageObj.getVerifyCertificationList();
                if (certificate == newCertificate)
                {
                    test.Pass("Added Certificate data and Expected Certificate data match");
                }
                else
                {
                    test.Pass("Added Certificate data and Expected Certificate data do not match");
                }
            }
        }
        [Test, Order(2)]
        public void UpdateCertificationData_Test()
        {
            string sFile = "UpdateCertificationPositiveData.json";
            // Read test data from the JSON file using JsonHelper
            List<CertificationsTestModel> UpdateCertificationPositiveData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine(UpdateCertificationPositiveData.ToString());
            foreach (var data in UpdateCertificationPositiveData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                // Perform the education test using the Education data
                try
                {
                    CertificationPageObj.updateCertifications(certificate, certifiedFrom, year);
                    test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                    string screenshotPath = CaptureScreenshot(driver, "UpdateCerification");
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

                    string newUpdatedCertificate = CertificationPageObj.getVerifyUpdateCertificationsList();
                    string verifyRecord = $"//tbody/tr[td[text()='{certificate}'] and td[text()='{year}']]//span[1]";
                    IWebElement desiredElement = driver.FindElement(By.XPath(verifyRecord));
                    if (desiredElement != null && desiredElement.Displayed)

                    {
                        test.Pass("Updated Certificate data and Expected Certificate data match");
                    }
                    else
                    {
                        test.Fail("Updated Certificate data and Expected Certificate data do not match");
                    }
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Upadated element not found", certificate.ToString());
                }

            }
        }
        [Test, Order(3)]
        public void DeleteCertificationData_Test()
        {
            string sFile = "DeleteCertificationData.json";
            // Read test data from the JSON file using JsonHelper
            List<CertificationsTestModel> DeleteCertificationData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine(DeleteCertificationData.ToString());
            foreach (var data in DeleteCertificationData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                // Perform the education test using the Education data
                CertificationPageObj.deleteCertification(certificate, year);
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                string screenshotPath = CaptureScreenshot(driver, "DeleteCerification");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

                string deletedCertificate = CertificationPageObj.getVerifyDeleteCertificationList();
                if (certificate != deletedCertificate)
                {
                    test.Pass("Deleted Certificate data and Expected Certificate data do not  match");
                }
                else
                {
                    test.Fail("Deleted Certificate data and Expected Certificate data match");
                }
            }
        }
        [TearDown]
        public void TearDown()
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

