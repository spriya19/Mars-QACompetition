using MarsCompetitionTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Pages
{
    public class CertificationNegativePage : CommonDriver
    {
        private static IWebElement certificationsTab => driver.FindElement(By.XPath("//a[normalize-space()='Certifications']"));
        private static IWebElement addNewButton => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));
        private static IWebElement certificateTextbox => driver.FindElement(By.Name("certificationName"));
        private static IWebElement certifiedFromTextbox => driver.FindElement(By.Name("certificationFrom"));
        private static IWebElement yearDropdown => driver.FindElement(By.Name("certificationYear"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement messageBox => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        public void addCertifications(string certificate, string certifiedFrom, string year)
        {
            //Click on certification tab
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 10);
            certificationsTab.Click();
            //Click on AddNew button
            addNewButton.Click();
            //Send the input
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            //Click on Add button
            addButton.Click();
            Thread.Sleep(2000);
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is: " + popupMessage);
            //string expectedMessage1 = "AWS Beginner has been added to your certification";
            string expectedMessage1 = "This information is already exist.";
            string expectedMessage2 = "Duplicated data";
            string expectedMessage3 = "Please enter Certification Name, Certification From and Certification Year";
            if (popupMessage.Contains("has been added to your certification"))
            {
                Console.WriteLine("Certifications has been added successfully");
            }
            else if((popupMessage == expectedMessage1) || (popupMessage == expectedMessage2) || (popupMessage == expectedMessage3))
            {
                IWebElement cancelIcon = driver.FindElement(By.XPath("//div[@class='five wide field']//input[@value='Cancel']"));
                cancelIcon.Click();
            }
            else
            {
                Console.WriteLine("Inside else condition, Check Error");
            }
        }
        public void UpdateCertifications(string certificate, string certifiedFrom, string year)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 10);
            certificationsTab.Click();
           string editiconXPath = $"//tbody/tr[td[text()='{certificate}']]//span[1]";
           IWebElement editIcon = driver.FindElement(By.XPath(editiconXPath));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            editIcon.Click();
            certificateTextbox.Clear();
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.Clear();
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            updateButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            //get the popup message text
            Thread.Sleep(2000);
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is: " + popupMessage);
            // string expectedMessage1 = "Certifications as been updated.";
            string expectedMessage1 = "Please enter Certification Name, Certification From and Certification Year";
            string expectedMessage2 = "This information is already exist.";

            if (popupMessage.Contains("has been updated to your certification"))
            {
                Console.WriteLine("Certifications has been updated sucessfully");
            }
            else if ((popupMessage == expectedMessage1) || (popupMessage == expectedMessage2))

            {
                IWebElement cancelIcon = driver.FindElement(By.XPath("//input[@value='Cancel']"));
                cancelIcon.Click();
            }
            else
            {
                Console.WriteLine("check error");
            }
        }
    }
}
    


