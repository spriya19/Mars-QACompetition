using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Utilities
{
    public class CommonDriver
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static IWebDriver driver;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }
        public void Close()
        {
            driver.Close();
        }
    }
}
  
