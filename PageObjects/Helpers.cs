using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OmadaWebsiteTests.Helpers
{
    class Helpers
    {
        /// <summary>
        /// Method that tries to wait
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="byOfElementToWaitForToBeVisable"></param>
        public static void Wait(IWebDriver driver, By byOfElementToWaitForToBeVisable)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(byOfElementToWaitForToBeVisable));
        }


        public static bool CheckIfFileExist(IWebDriver driver, string downloadsPath, string fileName)
        {
            //FileInfo fileInfo = new FileInfo($"{downloadsPath}/{fileName}");

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until<bool>(x => File.Exists($"{downloadsPath}/{fileName}"));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
