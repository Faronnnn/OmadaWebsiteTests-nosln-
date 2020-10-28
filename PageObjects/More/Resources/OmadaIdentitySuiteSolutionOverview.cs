using System;
using System.Collections.Generic;
using System.Text;
using OmadaWebsiteTests.PageObjects.Base;
using OpenQA.Selenium;

namespace OmadaWebsiteTests.PageObjects.More.Resources
{
    public class OmadaIdentitySuiteSolutionOverview :AbstractPage
    {

        public OmadaIdentitySuiteSolutionOverview(IWebDriver driver) : base(driver)
        {
            _address = "/en-us/more/resources/omada-identity-suite-solution-overview";
        }

        private IWebElement _downloadGuideButton => _driver.FindElement(By.CssSelector("a[class='cases__button button--variant2'][href='https://go.omada.net/l/581103/2020-07-30/46gzg3']"));
        private IWebElement _downloadSolutionSheetButton => _driver.FindElement(By.CssSelector("a[class='cases__button button--variant2'][href='https://go.omada.net/l/581103/2020-07-30/46gzfy']"));

        public void DownloadGuide()
        {
            _downloadGuideButton.Click();
        }

        public void DownloadSolutionSheet()
        {
            _downloadGuideButton.Click();
        }
    }
}
