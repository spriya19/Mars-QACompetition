using MarsCompetitionTask.Utilities;
using Microsoft.Azure.Amqp.Framing;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Pages
{
    public class CertificationPage : CommonDriver

    {
        private static IWebElement certificationsTab => driver.FindElement(By.XPath("//a[text()='Certifications']"));
        private static IWebElement addNewButton => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));
        private static IWebElement certificateTextbox => driver.FindElement(By.XPath("//input[@class='certification-award capitalize']"));
        private static IWebElement certifiedFromTextbox => driver.FindElement(By.XPath("//input[@class='received-from capitalize']"));
        private static IWebElement yearDropdown => driver.FindElement(By.Name("certificationYear"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement newCertification => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement updateCertificate => driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
        private static IWebElement updateCertifiedFrom => driver.FindElement(By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement newUpdatedCertificate => driver.FindElement(By.XPath(".//div[@data-tab='fourth']//table//td"));
        private static IWebElement deletedCertificate => driver.FindElement(By.XPath(".//div[@data-tab='fourth']//table//td"));
        private static IWebElement messageBox => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        public void addCertifications(string certificate, string certifiedFrom, string year)
        {
            //Click on certification tab
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 10);
            certificationsTab.Click();
            //Click on AddNew button
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 10);
            Thread.Sleep(1000);
            addNewButton.Click();
            //Send the input
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            //Click on Add button
            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 8);
           addButton.Click();
            Console.WriteLine("Certifications has been added");
           
        }
        public string getVerifyCertificationList()
        {
            Thread.Sleep(2000);
            return newCertification.Text;
        }
        public void updateCertifications(string certificate, string certifiedFrom, string year)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 10);
            certificationsTab.Click();
            string editiconXPath = $"//tbody/tr[td[text()='{certificate}'] and td[text()='{year}']]//span[1]";
            IWebElement editIcon = driver.FindElement(By.XPath(editiconXPath));
            Thread.Sleep(2000);
            editIcon.Click();
            certificateTextbox.Clear();
            updateCertificate.SendKeys(certificate);
            certifiedFromTextbox.Clear();
            updateCertifiedFrom.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            updateButton.Click();
            Console.WriteLine("Certification has been updated");
           
        }
        public string getVerifyUpdateCertificationsList()
        {
            Wait.WaitToBeVisible(driver, "XPath", ".//div[@data-tab='fourth']//table//td", 20);
            Thread.Sleep(1000);
            return newUpdatedCertificate.Text;
        }
        public void deleteCertification(string certificate, string year)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 8);
            certificationsTab.Click();
            string deleteiconXPath = $"//tbody/tr[td[text()='{certificate}'] and td[text()='{year}']]//span[2]";
            IWebElement deleteIcon = driver.FindElement(By.XPath(deleteiconXPath));
            deleteIcon.Click();
            Console.WriteLine("certification deleted from your Certifications");
        }
        public string getVerifyDeleteCertificationList()
        {
            Wait.WaitToBeVisible(driver, "XPath", ".//div[@data-tab='fourth']//table//td", 5);
            Thread.Sleep(1000);
            return deletedCertificate.Text;
        }
        public void addNegativeCertifications(string certificate, string certifiedFrom, string year)
        {
            //Click on certification tab
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 10);
            certificationsTab.Click();
            //Click on AddNew button
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 10);
            Thread.Sleep(1000);
            addNewButton.Click();
            //Send the input
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            //Click on Add button
            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 8);
            addButton.Click();
            Console.WriteLine("Certifications has been added");
            Wait.WaitToBeVisible(driver, "Xpath", "//div[@class='ns-box-inner']", 5);
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
            else if ((popupMessage == expectedMessage1) || (popupMessage == expectedMessage2) || (popupMessage == expectedMessage3))
            {
                IWebElement cancelIcon = driver.FindElement(By.XPath("//div[@class='five wide field']//input[@value='Cancel']"));
                cancelIcon.Click();
            }
            else
            {
                Console.WriteLine("Inside else condition, Check Error");
            }
        }

        public void updateNegativeCertifications(string certificate, string certifiedFrom, string year)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 10);
            certificationsTab.Click();
            string editiconXPath = $"//tbody/tr[td[text()='{certificate}']]//span[1]";
            IWebElement editIcon = driver.FindElement(By.XPath(editiconXPath));
            editIcon.Click();
            certificateTextbox.Clear();
            updateCertificate.SendKeys(certificate);
            certifiedFromTextbox.Clear();
            updateCertifiedFrom.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            updateButton.Click();
            Console.WriteLine("Certification has been updated");
            //get the popup message text
            Wait.WaitToBeVisible(driver, "Xpath", "//div[@class='ns-box-inner']", 5);
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
