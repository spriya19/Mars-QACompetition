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

namespace MarsCompetitionTask.Tests
{
    [TestFixture]
    public class EducationNegativeTest : CommonDriver
    {

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
            }
        }

        [TearDown]
        public void TearDownAction()
        {
            driver.Quit();
        }
    }
}
