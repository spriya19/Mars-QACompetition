using AventStack.ExtentReports;
using MarsCompetionTask.Utilities;
using MarsCompetitionTask.Pages;
using MarsCompetitionTask.TestModel;
using MarsCompetitionTask.Utilities;
using MarsCompetitionTask.Utilities.ExtentReport;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Tests
{
    [TestFixture]
    public class NeagtiveTest : CommonDriver
    {
#pragma warning disable CS8618

        private ExtentReports extent;
        private ExtentTest test;

        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private EducationPage educationPageObj = new EducationPage();
        private CertificationPage CertificationPageObj = new CertificationPage();

        [SetUp]
        public void SetupAuction()
        {
            extent = BaseReportManager.getInstance();
            driver = new ChromeDriver();
            //Login page object identified and defined
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj.LoginSteps();




        }

        [Test, Order(1)]
        public void AddNegativeEducation_Test()
        {
            test = extent.CreateTest("AddNegativeEducation_Test", "AddEducationNegativeData");

            string sFile = "AddEducationNegativeData.json";
            // Read test data from the JSON file using JsonHelper
            List<EducationTestModel> AddEducationNegativeData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(AddEducationNegativeData.ToString());
            foreach (var data in AddEducationNegativeData)
            {
                string university = data.University;
                Console.WriteLine(university);
                string country = data.Country;
                Console.WriteLine(country);
                string title = data.Title;
                Console.WriteLine(title);
                string degree = data.Degree;
                Console.WriteLine(degree);
                string graduationyear = data.Graduationyear;
                Console.WriteLine(graduationyear);
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "AddNegativeEducation");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                educationPageObj.addNegativeEdu(university, country, title, degree, graduationyear);


            }
        }
        [Test, Order(2)]
        public void updateNegativeEducation_Test()
        {
            test = extent.CreateTest("UpdateNegativeEducation_Test", "UpdateEducationNegativeData");

            // Read test data from the JSON file using JsonHelper
            string sFile = "UpdateEducationNegativeData.json";
            List<EducationTestModel> UpdateEducationNegativeData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(UpdateEducationNegativeData.ToString());
            foreach (var data in UpdateEducationNegativeData)
            {
                // Access the LoginData values
                string university = data.University;
                Console.WriteLine(university);
                string country = data.Country;
                Console.WriteLine(country);
                string title = data.Title;
                Console.WriteLine(title);
                string degree = data.Degree;
                Console.WriteLine(degree);
                string graduationyear = data.Graduationyear;
                Console.WriteLine(graduationyear);
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "UpdateNegativeEducation");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }
                educationPageObj = new EducationPage();
                educationPageObj.updateNegativeEdu(university, country, title, degree, graduationyear);



            }
        }
        [Test, Order(3)]
        public void AddNegativeCertification_Test()
        {
            test = extent.CreateTest("AddNegativeCertification_Test", "AddCertificationNegativeData");

            string sFile = "AddCertificationNegativeData.json";
            // Read test data from the JSON file using JsonHelper
            List<CertificationsTestModel> AddCertificationNegativeData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine(AddCertificationNegativeData.ToString());
            foreach (var data in AddCertificationNegativeData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "AddNegativeCertification");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                // Perform the education test using the Education data
                CertificationPageObj.addNegativeCertifications(certificate, certifiedFrom, year);
            }
        }
        [Test, Order(4)]
        public void UpdateNegativeCertification_Test()
        {
            test = extent.CreateTest("UpdateNegativeCertification_Test", "UpdateCertificationNegativeData");

            string sFile = "UpdateCertificationNegativeData.json";
            // Read test data from the JSON file using JsonHelper
            List<CertificationsTestModel> UpdateCertificationNegativeData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine(UpdateCertificationNegativeData.ToString());
            foreach (var data in UpdateCertificationNegativeData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "UpdateNegativeCertification");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }
                CertificationPageObj.updateNegativeCertifications(certificate, certifiedFrom, year);

            }
        }

       [TearDown]

        public void TearDownAction()
        {
            driver.Quit();
            extent.Flush();
        }
    }
}
