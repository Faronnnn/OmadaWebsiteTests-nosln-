using System;
using System.Collections.Generic;
using System.Text;
using OmadaWebsiteTests.PageObjects.Base;
using OmadaWebsiteTests.PageObjects.External;
using OpenQA.Selenium;

namespace OmadaWebsiteTests.PageObjects.More.Career
{
    public class JobsPage : AbstractPage
    {
        public JobsPage(IWebDriver driver) : base(driver)
        {
            _address = "/en-us/more/career/jobs";
        }

        private IWebElement _careerPortalButton => _driver.FindElement(By.CssSelector("a[class='text__button button--variant1'][href='https://candidate.hr-manager.net/vacancies/list.aspx?customer=omada']"));

        public CandidateManagerPage OpenCareerPortal()
        {
            _careerPortalButton.Click();
            return new CandidateManagerPage(_driver);
        }
    }
}
