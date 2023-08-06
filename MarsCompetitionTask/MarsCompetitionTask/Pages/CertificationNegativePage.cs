using MarsCompetitionTask.Utilities;
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
        private static IWebElement newCertification => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement newUpdatedCertificate => driver.FindElement(By.XPath(".//div[@data-tab='fourth']//table//td"));
        private static IWebElement deletedCertificate => driver.FindElement(By.XPath(".//div[@data-tab='fourth']//table//td"));
        public void addCertifications(string certificate, string certifiedFrom, string year)
        {
            //Click on certification tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ui top attached tabular menu']/a[3]", 6);
            certificationsTab.Click();
            //Click on AddNew button
            addNewButton.Click();
            //Send the input
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            //Click on Add button
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
    }
}

