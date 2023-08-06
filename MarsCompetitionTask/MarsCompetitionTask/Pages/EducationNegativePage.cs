using MarsCompetitionTask.TestModel;
using MarsCompetitionTask.Utilities;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Pages
{
    public class EducationNegativePage : CommonDriver
    {
        private static IWebElement educationTab => driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']//a[3]"));
        private static IWebElement addNewButton => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));
        private static IWebElement universityTextBox => driver.FindElement(By.Name("instituteName"));
        private static IWebElement countryDropDown => driver.FindElement(By.Name("country"));
        private static IWebElement titleDropDown => driver.FindElement(By.Name("title"));
        private static IWebElement degreeTextBox => driver.FindElement(By.Name("degree"));
        private static IWebElement graduationyearDropDown => driver.FindElement(By.Name("yearOfGraduation"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement messageBox => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        //private static IWebElement createdRecord => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        public void addEducation(string university, string country, string title, string degree, string graduationyear)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui top attached tabular menu']//a[3]", 5);
            educationTab.Click();
            Thread.Sleep(2000);
            addNewButton.Click();
            Wait.WaitToBeClickable(driver, "Name", "instituteName", 5);
            universityTextBox.SendKeys(university);
            countryDropDown.SendKeys(country);
            titleDropDown.SendKeys(title);
            degreeTextBox.SendKeys(degree);
            graduationyearDropDown.SendKeys(graduationyear);
            addButton.Click();
            Wait.WaitToBeVisible(driver, "Xpath", "//div[@class='ns-box-inner']", 5);
            Thread.Sleep(2000);
            string popupMessage = messageBox.Text;
            Console.WriteLine(popupMessage);
            string expectedMessage1 = "Education has been added";
            string expectedMessage2 = "Please enter all the fields";
            string expectedMessage3 = "This information is already exist";
            string expectedMessage4 = "Education information was invalid";
            string expectedMessage5 = "Duplicated data";
            // Assert.That(popupMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));
            if (popupMessage == expectedMessage1)
            {
                Console.WriteLine("Education has been added successfully");
            }
            else if (popupMessage == expectedMessage2 || popupMessage == expectedMessage3 || popupMessage == expectedMessage4 || popupMessage == expectedMessage5)
            {
                IWebElement cancelIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[2]"));
                cancelIcon.Click();
            }
        }
        public void updateEducation(string university, string country, string title, string degree, string graduationyear)
        {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui top attached tabular menu']//a[3]", 5);
                educationTab.Click();
           // Thread.Sleep(2000);
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
                Wait.WaitToBeVisible(driver, "Xpath", "//div[@class='ns-box-inner']", 5);
                Thread.Sleep(2000);
                string popupMessage = messageBox.Text;
                Console.WriteLine(popupMessage);
                string expectedMessage1 = "Education as been Updated";
                string expectedMessage2 = "Please enter all the fields"; 
                string expectedMessage3 = "This information is already exist";
                if (popupMessage == expectedMessage1)
                {
                    Console.WriteLine("Education as been updated successfully");
                }
                else if (popupMessage == expectedMessage2 || popupMessage == expectedMessage3)
                {
                    IWebElement cancelIcon = driver.FindElement(By.XPath("//tbody//input[@value='Cancel']"));
                    cancelIcon.Click();
                }
        }

        
    }
}
