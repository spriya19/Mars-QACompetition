using MarsCompetitionTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Pages
{
    public class LoginTestPage : CommonDriver
    {


        private static IWebElement signInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private static IWebElement emailTextBox => driver.FindElement(By.Name("email"));
        private static IWebElement passwordTextBox => driver.FindElement(By.Name("password"));
        private static IWebElement rememberme => driver.FindElement(By.Name("rememberDetails"));
        private static IWebElement loginButton => driver.FindElement(By.XPath("//button[normalize-space()='Login']"));

        public void navigateSteps()
        {
            //Launch portal
            driver.Navigate().GoToUrl("http://localhost:5000/");
            //Thread.Sleep(3000);
            driver.Manage().Window.Maximize();

        }
        public void loginSteps() 
        {
            signInButton.Click();
            emailTextBox.SendKeys("spriyak86@gmail.com");
            passwordTextBox.SendKeys("121212");
            rememberme.Click();
            loginButton.Click();
        }
    }
}
