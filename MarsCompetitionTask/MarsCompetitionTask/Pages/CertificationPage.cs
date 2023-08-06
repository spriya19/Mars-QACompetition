using MarsCompetitionTask.Utilities;
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
        private static IWebElement certificationsTab => driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']//a[4]"));
        private static IWebElement addNewButton => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));
        private static IWebElement certificateTextbox => driver.FindElement(By.Name("certificationName"));
        private static IWebElement certifiedFromTextbox => driver.FindElement(By.Name("certificationFrom"));
        private static IWebElement yearDropdown => driver.FindElement(By.Name("certificationYear"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement newCertification => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement newUpdatedCertificate => driver.FindElement(By.XPath(".//div[@data-tab='fourth']//table//td"));
        private static IWebElement deletedCertificate => driver.FindElement(By.XPath(".//div[@data-tab='fourth']//table//td"));
        public void addCertifications(string certificate, string certifiedFrom, string year)
        {
            //Thread.Sleep(3000);
            //Click on certification tab
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui top attached tabular menu']//a[4]", 5);
            certificationsTab.Click();
            //Click on AddNew button
            addNewButton.Click();
            //Send the input
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            //Click on Add button
            addButton.Click();
            Console.WriteLine("Certifications has been added");
        }
        public string getVerifyCertificationList()
        {
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[1]", 20);
            Thread.Sleep(2000);
            return newCertification.Text;
        }
        public void updateCertifications(string certificate, string certifiedFrom, string year)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui top attached tabular menu']//a[4]", 6);
            certificationsTab.Click();
            string editiconXPath = $"//tbody/tr[td[text()='{certificate}'] and td[text()='{year}']]//span[1]";
            IWebElement editIcon = driver.FindElement(By.XPath(editiconXPath));
            editIcon.Click();
            certificateTextbox.Clear();
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.Clear();
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            updateButton.Click();
            Console.WriteLine("Certification has been updated");
        }
        public string getVerifyUpdateCertificationsList()
        {
            // Wait.WaitToBeVisible(driver, "XPath", ".//div[@data-tab='fourth']//table//td", 6);
            Thread.Sleep(2000);
            return newUpdatedCertificate.Text;
        }
        public void deleteCertification(string certificate, string year)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui top attached tabular menu']//a[4]", 8);
            certificationsTab.Click();
            string deleteiconXPath = $"//tbody/tr[td[text()='{certificate}'] and td[text()='{year}']]//span[2]";
            IWebElement deleteIcon = driver.FindElement(By.XPath(deleteiconXPath));
            Thread.Sleep(1000);
            deleteIcon.Click();
            Console.WriteLine("certification deleted from your Certifications");
        }
        public string getVerifyDeleteCertificationList()
        {
            //Wait.WaitToBeVisible(driver, "XPath", ".//div[@data-tab='fourth']//table//td", 20);
            Thread.Sleep(1000);
            return deletedCertificate.Text;
        }

    }


}
