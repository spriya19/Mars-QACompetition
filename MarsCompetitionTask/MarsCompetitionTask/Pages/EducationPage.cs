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


namespace MarsCompetitionTask.Pages
{
    public class EducationPage : CommonDriver
    {
        private static IWebElement educationTab => driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']//a[3]"));
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
        public void addEducation(string university, string country, string title, string degree, string graduationyear)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui top attached tabular menu']//a[3]", 13);
            educationTab.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 6);
            addNewButton.Click();
            universityTextBox.SendKeys(university);
            countryDropDown.SendKeys(country);
            titleDropDown.SendKeys(title);
            degreeTextBox.SendKeys(degree);
            graduationyearDropDown.SendKeys(graduationyear);
            addButton.Click();
           
        }

        public string getVerifyNewEducationData()
        {
            
            return newEducationData.Text;
            

        }
        public void updateEducation(string university,string country,string title,string degree,string graduationyear)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui top attached tabular menu']//a[3]", 5);
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
            updateButton.Click();
        }

       public string getverifyUpdatedEducationData()
       {
            Wait.WaitToBeVisible(driver, "XPath", ".//div[@data-tab='third']//table[@class='ui fixed table']//td", 4);
            return verifyUpdatedEducationData.Text;          
       }
        public void deleteEduData(string university, string degree)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui top attached tabular menu']//a[3]", 5);
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
    }
}
