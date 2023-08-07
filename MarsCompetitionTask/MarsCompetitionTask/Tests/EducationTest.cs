
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using com.sun.tools.@internal.jxc.ap;
using javax.xml.crypto;
using MarsCompetitionTask.Pages;
using MarsCompetitionTask.TestModel;
using MarsCompetitionTask.Utilities;
using Microsoft.AspNetCore.Routing.Matching;
using MongoDB.Driver.Core.Misc;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V112.Page;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO.Enumeration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static javax.jws.soap.SOAPBinding;

namespace MarsCompetitionTask.Tests
{
    [TestFixture]
    public class EducationTest : CommonDriver
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
        }

        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private EducationPage educationPageObj = new EducationPage();
        
        
        
        [SetUp]
        public void SetUpAction()
        {
            driver = new ChromeDriver();
           //Login page object identified and defined
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj.navigateSteps();
            loginTestPageObj.loginSteps();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }


        [Test, Order(1)]
        public void AddEducationData_Test()
        {
            string sFile = "AddEducationPositiveData.json";
            // Read test data from the JSON file using JsonHelper
            List<EducationTestModel> AddEducationPositiveData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(AddEducationPositiveData.ToString());

            foreach (var data in AddEducationPositiveData)
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
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                string screenshotPath = CaptureScreenshot(driver, "AddEducation");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

                educationPageObj.addEducation(university, country, title, degree, graduationyear);
                string newEducationData = educationPageObj.getVerifyNewEducationData();
                if (country == newEducationData)
                {
                    //Assert.AreEqual(country, newEducationData, "Added Education and Expected Education do not match");
                    test.Pass("Added Education and Expected Education match");

                }
                else
                {
                    // Console.WriteLine("Check error");
                    test.Fail("Added Education and Expected Education do not match");
                }
                Console.WriteLine("Education has been Added");
            }
        }

        [Test, Order(2)]
        public void updateEducationData_Test()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "UpdateEducationPositiveData.json";
            List<EducationTestModel> UpdateEducationPositiveData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(UpdateEducationPositiveData.ToString());
            foreach (var data in UpdateEducationPositiveData)
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
                try
                {
                    //perform the education test using the Education data
                    educationPageObj = new EducationPage();
                   educationPageObj.updateEducation(university, country, title, degree, graduationyear);
                    test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                    string screenshotPath = CaptureScreenshot(driver, "UpdateEducation");
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

                    string updatedEducationData = educationPageObj.getverifyUpdatedEducationData();
                    string verifyRecord = $"//tbody/tr[td[text()='{university}'] and td[text()='{degree}']]//span[1]";

                    IWebElement desiredElement = driver.FindElement(By.XPath(verifyRecord));

                    // Step 2: Perform the verification
                    //Console.WriteLine("Verification for updated record");
                    Console.WriteLine("Expected Data: " + country);
                    Console.WriteLine("Updated Education Data: " + updatedEducationData);
                    if (desiredElement != null && desiredElement.Displayed)

                    {
                        test.Pass("Updated Education and Expected Education match");
                    }
                    else
                    {
                        test.Fail("Updated Education and Expected Education do not match");
                    }
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Upadated element not found", university.ToString());
                }

            }
        }
        [Test, Order(3)]
        public void deleteEducation_Test()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "DeleteData.json";
            List<EducationTestModel> DeleteData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(DeleteData.ToString());
            foreach (var data in DeleteData)
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
                //perform the education test using the Education data
                educationPageObj = new EducationPage();
                educationPageObj.deleteEduData(university, degree);
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                string screenshotPath = CaptureScreenshot(driver, "DeleteEducation");
                test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

                string DeletedData = educationPageObj.getVerifyDeletedData();
                if (country != DeletedData)
                {
                    // Assert.AreEqual(country, DeletedData, "Actual updated education data and expected updated education data do not match");
                    test.Pass("Deleted Education and Expected Education do not match");

                }
                else
                {
                    //Assert.AreNotEqual(country, DeletedData, "Actual updated education data and expected updated education data do match");
                    test.Fail("Deleted Education and Expected Education  match");
                }
                Console.WriteLine("Education Entry successfully removed");
            }
        }
        [TearDown]

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

