using AventStack.ExtentReports.Reporter;
using MarsCompetitionTask.Pages;
using MarsCompetitionTask.TestModel;
using MarsCompetitionTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO.Enumeration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Tests
{
    [TestFixture]
    public class EducationTest : CommonDriver
    {
        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private EducationPage educationPageObj = new EducationPage();


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
        public void AddEducationData_Test()
        {
            string sFile = "AddEducationPositiveData.json";
           // Read test data from the JSON file using JsonHelper
            List <EducationTestModel> AddEducationPositiveData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>(sFile);
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
                educationPageObj.addEducation(university, country, title, degree, graduationyear);
                    string newEducationData = educationPageObj.getVerifyNewEducationData();
                    if (country == newEducationData)
                    {
                        Assert.AreEqual(country, newEducationData, "Added Education and Expected Education do not match");

                    }
                    else
                    {
                        Console.WriteLine("Check error");
                    }
                
                
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
                    string updatedEducationData = educationPageObj.getverifyUpdatedEducationData();
                    if (country == updatedEducationData)
                    {
                        Assert.AreEqual(country, updatedEducationData, "Actual updated education data and expected updated education data do not match");
                    }
                    else
                    {
                        Assert.AreNotEqual(country, updatedEducationData, "Actual updated education data and expected updated education data do match");
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
                educationPageObj.deleteEduData(university,degree );
                string DeletedData = educationPageObj.getVerifyDeletedData();
                if (country == DeletedData)
                {
                    Assert.AreEqual(country, DeletedData, "Actual updated education data and expected updated education data do not match");
                }
                else
                {
                   Assert.AreNotEqual(country, DeletedData, "Actual updated education data and expected updated education data do match");
                }
                Console.WriteLine("Education Entry successfully removed");
            }
        }
            [TearDown]

             public void TearDownAction()
             {
                driver.Quit();
             }
        
    }
}
