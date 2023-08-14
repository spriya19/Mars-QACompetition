using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MarsCompetionTask.Utilities
{
    public class ScreenshotReport
    {
        public static string CaptureScreenshot(IWebDriver driver, string screenshotName)
        {
            try
            {
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                string screenshotPath = Path.Combine("NunitScreenshot", $"{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png");
                string fullPath = Path.Combine("C:\\priya\\Intenship\\Competition Task\\Mars-QACompetition\\MarsCompetitionTask\\MarsCompetitionTask\\", screenshotPath);
                screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
                return fullPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturing screenshot: " + ex.Message);
                return "";
            }
        }
    }
}