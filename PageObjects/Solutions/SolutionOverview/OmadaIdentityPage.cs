using OmadaWebsiteTests.PageObjects.Base;
using OmadaWebsiteTests.PageObjects.More.Company;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmadaWebsiteTests.PageObjects.Solutions.SolutionOverview
{
    public class OmadaIdentityPage : AbstractPage
    {
        public OmadaIdentityPage(IWebDriver driver) : base(driver)
        {
            _address = "/en-us/solutions/solution-overview/omada-identity";
        }

        private IWebElement _contactOmadaButton => _driver.FindElement(By.CssSelector("a[class='text__button button--variant1'][href='/en-us/more/company/contact']"));
        private IWebElement _coreFeaturesButton => _driver.FindElement(By.CssSelector("a[class='text__button button--variant1'][href='/en-us/solutions/core-functionality']"));

        public ContactPage OpenContactOmada()
        {
            _contactOmadaButton.Click();
            return new ContactPage(_driver);
        }

        public void OpenCoreFeatures()
        {
            _coreFeaturesButton.Click();
        }
    }
}
