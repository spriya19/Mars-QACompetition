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

namespace MarsCompetitionTask.Tests
{
    [TestFixture]
    public class EducationNegativeTest : CommonDriver 
    {
#pragma warning disable CS8618

        private ExtentReports extent;
        private ExtentTest test;
        [OneTimeSetUp]
        public void SetupReporting()
        {
            string reportPath = "C:\\priya\\Intenship\\Competition Task\\Mars-QACompetition\\MarsCompetitionTask\\MarsCompetitionTask\\Utilities\\Extent\\BaseTest.cs";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private EducationNegativePage educationNegativePageObj = new EducationNegativePage();




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
            //test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }

        [Test, Order(1)]
        public void AddEducationData_Test()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "AddEducationNegativeData.json";
           List<EducationTestModel> AddEducationNegativeData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(AddEducationNegativeData.ToString());
            foreach (var data in AddEducationNegativeData)
            {
                // Access the LoginData values
                string university = data.University;
                //Console.WriteLine(university);
                string country = data.Country;
                //Console.WriteLine(country);
                string title = data.Title;
                //Console.WriteLine(title);
                string degree = data.Degree;
                //Console.WriteLine(degree);
                string graduationyear = data.Graduationyear;
                //Console.WriteLine(graduationyear);
                educationNegativePageObj.addEducation(university, country, title, degree, graduationyear);
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                string screenshotPath = CaptureScreenshot(driver, "AddEducationNegative");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

            }
        }
        [Test, Order(2)]
        public void UpdateEducationData_Test()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "UpdateEducationNegativeData.json";
            List<EducationTestModel> UpdateEducationNegativeData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(UpdateEducationNegativeData.ToString());
            foreach (var data in UpdateEducationNegativeData)
            {
                
                string university = data.University;
                string country = data.Country;
                string title = data.Title;
                string degree = data.Degree;
                string graduationyear = data.Graduationyear;
                educationNegativePageObj.updateEducation(university, country, title, degree, graduationyear);
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                string screenshotPath = CaptureScreenshot(driver, "UpdateEducationNegative");
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
