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

           signInButton.Click();
           emailTextBox.SendKeys("spriyak86@gmail.com");
           passwordTextBox.SendKeys("121212");
           loginButton.Click();
        }



    }
}
