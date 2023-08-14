using MarsCompetitionTask.TestModel;
using MarsCompetitionTask.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices.WindowsRuntime;
using MongoDB.Bson.Serialization.Conventions;

namespace MarsCompetitionTask.Pages
{
    public class EducationPage : CommonDriver
    {
        private static IWebElement educationTab => driver.FindElement(By.XPath("//a[text()='Education']"));
        private static IWebElement addNewButton => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));
        private static IWebElement universityTextBox => driver.FindElement(By.Name("instituteName"));
        private static IWebElement countryDropDown => driver.FindElement(By.Name("country"));
        private static IWebElement titleDropDown => driver.FindElement(By.Name("title"));
        private static IWebElement degreeTextBox => driver.FindElement(By.Name("degree"));
        private static IWebElement graduationyearDropDown => driver.FindElement(By.Name("yearOfGraduation"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement newEducationData => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement verifyUpdatedEducationData => driver.FindElement(By.XPath(".//div[@data-tab='third']//table[@class='ui fixed table']//td"));
        private static IWebElement deletedData => driver.FindElement(By.XPath(".//div[@data-tab='third']//table[@class='ui fixed table']//td"));
        private static IWebElement messageBox => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        public void addEducation(string university, string country, string title, string degree, string graduationyear)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Education']", 13);
            educationTab.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 12);
            Thread.Sleep(2000);
            addNewButton.Click();
            universityTextBox.SendKeys(university);
            countryDropDown.SendKeys(country);
            titleDropDown.SendKeys(title);
            degreeTextBox.SendKeys(degree);
            graduationyearDropDown.SendKeys(graduationyear);
            addButton.Click();
            Wait.WaitToBeVisible(driver, "Xpath", "//div[@class='ns-box-inner']", 5);
            Thread.Sleep(2000);
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is: " + popupMessage);
            //string expectedMessage1 = "Education has been added";
            string expectedMessage2 = "Please enter all the fields";
            string expectedMessage3 = "This information is already exist.";
            //string expectedMessage4 = "Education information was invalid";
            string expectedMessage4 = "Duplicated data";
            if (popupMessage.Contains("has been added"))
            {
                Console.WriteLine("Education has been added successfully");
            }
            else if ((popupMessage == expectedMessage2 || popupMessage == expectedMessage3 || popupMessage == expectedMessage4))
            {
                IWebElement cancelIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[2]"));
                cancelIcon.Click();
            }
            else
            {
                Console.WriteLine("Check Error");
            }


        }

        public string getVerifyNewEducationData()
        {
            Thread.Sleep(2000);
            return newEducationData.Text;
            

        }
        public void updateEducation(string university,string country,string title,string degree,string graduationyear)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Education']", 5);
            educationTab.Click();
            string editIconXPath = $"//tbody/tr[td[text()='{university}'] and td[text()='{degree}']]//span[1]";
            IWebElement editIcon = driver.FindElement(By.XPath(editIconXPath));
            editIcon.Click();
            universityTextBox.Clear();
            universityTextBox.SendKeys(university);
            countryDropDown.SendKeys(country);
            titleDropDown.SendKeys(title);
            degreeTextBox.Clear();
            degreeTextBox.SendKeys(degree);
            graduationyearDropDown.SendKeys(graduationyear);
            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Update']", 8);
            updateButton.Click();
            //Wait.WaitToBeVisible(driver, "Xpath", "//div[@class='ns-box-inner']", 5);
            Thread.Sleep(2000);
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is: " + popupMessage);
            //string expectedMessage1 = "Education as been Updated";
            string expectedMessage2 = "Please enter all the fields";
            string expectedMessage3 = "This information is already exist.";
            if (popupMessage.Contains("as been updated"))
            {
                Console.WriteLine("Education as been updated successfully");
            }
            else if ((popupMessage == expectedMessage2) || (popupMessage == expectedMessage3))
            {
                IWebElement cancelIcon = driver.FindElement(By.XPath("//input[@value='Cancel']"));
                cancelIcon.Click();
            }
            else
            {
                Console.WriteLine("Check Error");
            }
        }
       public string getverifyUpdatedEducationData()
       {
            Thread.Sleep(1000);
            return verifyUpdatedEducationData.Text;          
       }
        public void deleteEduData(string university, string degree)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Education']", 5);
            educationTab.Click();
            string deleteIconXPath = $"//tbody/tr[td[text()='{university}'] and td[text()='{degree}']]//span[2]";
            IWebElement deleteIcon = driver.FindElement(By.XPath(deleteIconXPath));
            deleteIcon.Click();
           
        }
        public string getVerifyDeletedData()
        {
            Thread.Sleep(1000);
            return deletedData.Text;
        }
        public void updateNegativeEdu(string university, string country, string title, string degree, string graduationyear)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Education']", 5);
            educationTab.Click();
            string editIconXPath = $"//tbody/tr[td[text()='{university}'] and td[text()='{degree}']]//span[1]";
            IWebElement editIcon = driver.FindElement(By.XPath(editIconXPath));
            editIcon.Click();
            universityTextBox.Clear();
            universityTextBox.SendKeys(university);
            countryDropDown.SendKeys(country);
            titleDropDown.SendKeys(title);
            degreeTextBox.Clear();
            degreeTextBox.SendKeys(degree);
            graduationyearDropDown.SendKeys(graduationyear);
            Thread.Sleep(1000);
            updateButton.Click();
            
        }


    }

}

