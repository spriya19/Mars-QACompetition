using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
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
using MarsCompetitionTask.Utilities.ExtentReport;
using MarsCompetionTask.Utilities;

namespace MarsCompetitionTask.Tests  
{
    [TestFixture]
    public class CertificationsTest : CommonDriver
    {
#pragma warning disable CS8618

        private ExtentReports extent;
        private ExtentTest test;

        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private CertificationPage CertificationPageObj = new CertificationPage();

        [SetUp]
        public void SetUpAction()
        {
            
            extent = BaseReportManager.getInstance();
            driver = new ChromeDriver();

            //Login page object identified and defined
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj.LoginSteps();
        }
        [Test, Order(1)]
        public void AddCertification_Test()
        {
            test = extent.CreateTest("AddCertification_Test", "AddCertificationData");

            string sFile = "AddCertificationData.json";
            // Read test data from the JSON file using JsonHelper
            List<CertificationsTestModel> AddCertificationData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine(AddCertificationData.ToString());
            foreach (var data in AddCertificationData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "AddCertification");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                // Perform the education test using the Education data
                CertificationPageObj.addCertifications(certificate, certifiedFrom, year);
              string newCertificate = CertificationPageObj.getVerifyCertificationList();
                if (certificate == newCertificate)
                {
                    test.Pass("Added Certificate data and Expected Certificate data match");
                }
                else
                {
                    test.Fail("Added Certificate data and Expected Certificate data do not match");
                }
            }
        }
        [Test, Order(2)]
        public void UpdateCertification_Test()
        {
            test = extent.CreateTest("UpdateCertification_Test", "UpdateCertificationData");

            string sFile = "UpdateCertificationData.json";
            // Read test data from the JSON file using JsonHelper
            List<CertificationsTestModel> UpdateCertificationData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine(UpdateCertificationData.ToString());
            foreach (var data in UpdateCertificationData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "UpdateCertification");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                // Perform the education test using the Education data
                try
                {
                    CertificationPageObj.updateCertifications(certificate, certifiedFrom, year);
                    
                    string newUpdatedCertificate = CertificationPageObj.getVerifyUpdateCertificationsList();
                    string verifyRecord = $"//tbody/tr[td[text()='{certificate}']]//span[1]";
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
        public void DeleteCertification_Test()
        {
            test = extent.CreateTest("DeleteCertification_Test", "DeleteCertificationData");

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
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "DeleteCertification");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                // Perform the education test using the Education data
                CertificationPageObj.deleteCertification(certificate, year);
                
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
        
    }
}

