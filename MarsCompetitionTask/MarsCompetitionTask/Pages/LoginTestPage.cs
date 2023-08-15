using MarsCompetitionTask.TestModel;
using MarsCompetitionTask.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Pages
{
    public class LoginTestPage :CommonDriver
    {
        private static IWebElement signInButton => driver.FindElement(By.XPath("//a[normalize-space()='Sign In']"));
        private static IWebElement emailTextBox => driver.FindElement(By.Name("email"));
        private static IWebElement passwordTextBox => driver.FindElement(By.Name("password"));
        //private static IWebElement rememberme => driver.FindElement(By.Name("rememberDetails"));
        private static IWebElement loginButton => driver.FindElement(By.XPath("//button[normalize-space()='Login']"));

        public void LoginSteps()
        {

            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();

            // Read login credentials from the JSON file
            string jsonFilePath = "C:\\priya\\Intenship\\Competition Task\\Mars-QACompetition\\MarsCompetitionTask\\MarsCompetitionTask\\JsonDataFiles\\LoginData.json";
            // Deserialize the JSON content into LoginCredentials object
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Parse JSON using JObject
            JObject jsonObject = JObject.Parse(jsonContent);
#pragma warning disable CS8602

            string email = jsonObject["email"].ToString();
            string password = jsonObject["password"].ToString();

            // Click the "Sign In" button
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Sign In']", 5);
            signInButton.Click();

            // Enter the provided email
            Wait.WaitToBeVisible(driver, "Name", "email", 5);
            emailTextBox.SendKeys(email);

            // Enter the provided password
            Wait.WaitToBeVisible(driver, "Name", "password", 5);
            passwordTextBox.SendKeys(password);

            // Click the "Login" button
            Wait.WaitToBeClickable(driver, "XPath", "//button[text()='Login']", 5);
            loginButton.Click();
            Thread.Sleep(3000);
        }


    }
}
