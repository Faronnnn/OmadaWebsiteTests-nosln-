using System;
using System.Collections.Generic;
using System.Text;
using OmadaWebsiteTests.PageObjects.Base;
using OmadaWebsiteTests.PageObjects.More.Company;
using OpenQA.Selenium;

namespace OmadaWebsiteTests.PageObjects
{
    class MainPage : AbstractPage
    {
        public MainPage(IWebDriver driver) : base(driver) 
        {
            _address = "/en-us";
        }

        private IWebElement _cookiesCloseButton => _driver.FindElement(By.CssSelector(".cookiebar__button.button--variant1"));

        private IWebElement _bookADemoButton => _driver.FindElement(By.CssSelector("a[class='slider__button'][href='/en-us/more/resources/request-an-omada-live-demo']"));
        private IWebElement _riskAndSecurityButton => _driver.FindElement(By.CssSelector("a[class='spots__button'][href='/en-us/business-value/security']"));
        private IWebElement _complianceAndTrustButton => _driver.FindElement(By.CssSelector("a[class='spots__button'][href='/en-us/business-value/compliance']"));
        private IWebElement _efficiencyAndEnablementButton => _driver.FindElement(By.CssSelector("a[class='spots__button'][href='/en-us/business-value/efficiency']"));
        private IWebElement _contactUsButton => _driver.FindElement(By.CssSelector("a[class='text__button button--variant1'][href='/en-us/more/company/contact']"));

        /// <summary>
        /// Opens Main Page in a browser.
        /// This method also closes the cookies info as soon as the site is loaded for the first time.
        /// </summary>
        public override void GoTo()
        {
            base.GoTo();
            _cookiesCloseButton.Click();
        }

        public void ClickBookADemoButton() // TODO: Change void to PageObjectType where this button leads.
        {
            _bookADemoButton.Click();
        }

        public void ClickRiskAndSecurityButton() // TODO: Change void to PageObjectType where this button leads.
        {
            _riskAndSecurityButton.Click();
        }

        public void ClickComplianceAndTrustButton() // TODO: Change void to PageObjectType where this button leads.
        {
            _complianceAndTrustButton.Click();
        }

        public void ClickEfficiencyAndEnablementButton() // TODO: Change void to PageObjectType where this button leads.
        {
            _efficiencyAndEnablementButton.Click();
        }

        public ContactPage ClickContactUsButton()
        {
            _contactUsButton.Click();
            return new ContactPage(_driver);
        }
    }
}
