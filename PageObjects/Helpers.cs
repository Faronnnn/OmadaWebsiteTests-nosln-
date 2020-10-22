using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
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
    }
}
