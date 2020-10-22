using OmadaWebsiteTests.PageObjects.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmadaWebsiteTests.PageObjects.Solutions
{
    public class SolutionOverviewPage : AbstractPage
    {
        public SolutionOverviewPage(IWebDriver driver) : base(driver)
        {
            _address = "/en-us/solutions/solution-overview";
        }
    }
}
