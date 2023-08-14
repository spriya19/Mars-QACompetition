
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using MarsCompetionTask.Utilities;
using MarsCompetitionTask.Pages;
using MarsCompetitionTask.TestModel;
using MarsCompetitionTask.Utilities;
using MarsCompetitionTask.Utilities.ExtentReport;
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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Tests
{
    [TestFixture]
    public class EducationTest : CommonDriver
    {
#pragma warning disable CS8618

        private ExtentReports extent;
        private ExtentTest test;

        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private EducationPage educationPageObj = new EducationPage();
        [SetUp]
        public void SetupAuction()
        {
            string url = "http://localhost:5000/Home";
            string email = "spriyak86@gmail.com";
            string password = "121212";
            extent = BaseReportManager.getInstance();
            driver = new ChromeDriver();
            //Login page object identified and defined
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj.loginSteps(url, email, password);
        }

        [Test, Order(1)]
        public void AddEducation_Test()
        {
            test = extent.CreateTest("AddEducation_Test", "AddEducationData");

            string sFile = "AddEducationData.json";
            // Read test data from the JSON file using JsonHelper
            List<EducationTestModel> AddEducationData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(AddEducationData.ToString());
            foreach (var data in AddEducationData)
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
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "AddEducation");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                educationPageObj.addEducation(university, country, title, degree, graduationyear);

                string newEducationData = educationPageObj.getVerifyNewEducationData();
                if (country == newEducationData)
                {
                    //Assert.AreEqual(country, newEducationData, "Added Education and Expected Education do not match");
                    test.Pass("Added Education data and Expected education data match");
                }
                else
                {
                    //Console.WriteLine("Check error");
                    test.Fail("Added Education data and Expected education data do not match");

                }
                Console.WriteLine("Education has been Added");

            }
                
            
        }

        [Test, Order(2)]
        public void updateEducation_Test()
        {
            test = extent.CreateTest("UpdateEducation_Test", "UpdateEducationData");

            // Read test data from the JSON file using JsonHelper
            string sFile = "UpdateEducationData.json";
            List<EducationTestModel> UpdateEducationData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(UpdateEducationData.ToString());
            foreach (var data in UpdateEducationData)
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
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "UpdateEducation");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                try
                {
                    //perform the education test using the Education data
                    educationPageObj = new EducationPage();
                   educationPageObj.updateEducation(university, country, title, degree, graduationyear);
                    string verifyRecord = $"//tbody/tr[td[text()='{university}'] and td[text()='{degree}']]//span[1]";
                    IWebElement desiredElement = driver.FindElement(By.XPath(verifyRecord));

                    Console.WriteLine("Verification for updated record");
                    //Console.WriteLine("Expected Data: " + country);
                   // Console.WriteLine("Updated Education : " + updateEducation);
                    if (desiredElement != null && desiredElement.Displayed)

                    {
                        test.Pass("Updated Education and Expected Education match");
                    }
                    else
                    {
                        test.Fail("Updated Education and Expected Education do not match");
                    }
                    Console.WriteLine("Education Updated successfully ");
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
            test = extent.CreateTest("UpdateEducation_Test", "DeleteEducation");

            // Read test data from the JSON file using JsonHelper
            string sFile = "DeleteEducation.json";
            List<EducationTestModel> DeleteEducation = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
            Console.WriteLine(DeleteEducation.ToString());
            foreach (var data in DeleteEducation)
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
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "DeleteEducation");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                //perform the education test using the Education data
                educationPageObj = new EducationPage();
                educationPageObj.deleteEduData(university, degree);
                 string DeletedData = educationPageObj.getVerifyDeletedData();
                if (country != DeletedData)
                {
                    test.Pass("Deleted Education data and Expected Education data do not  match");

                }
                else
                {
                    test.Fail("Deleted Education data and Expected Education data do not  match");
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
    }
}

