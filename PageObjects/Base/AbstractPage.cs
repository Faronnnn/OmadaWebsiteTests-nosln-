using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using NUnit.Framework.Internal;
using OmadaWebsiteTests.PageObjects.Base;
using OmadaWebsiteTests.PageObjects.More.Career;
using OmadaWebsiteTests.PageObjects.Solutions;
using OmadaWebsiteTests.PageObjects.Solutions.SolutionOverview;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OmadaWebsiteTests.PageObjects.Base
{
    // Base class to all PageObjects
    public class AbstractPage : AbstractBase
    {
        private string _omadaDomain = "https://www.omada.net";

        protected string _address;
        public AbstractPage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Go directly to this page.
        /// </summary>
        public virtual void GoTo()
        {
            _driver.Navigate().GoToUrl(_omadaDomain + _address);
        }

        public MainMenuBar MainMenu()
        {
            return new MainMenuBar(_driver);
        }


        public class MainMenuBar : AbstractBase
        {
            internal MainMenuBar(IWebDriver driver) : base(driver)
            { }

            // main Menu Bar selectors
            private IWebElement _solutionsSectionBarItem => _driver.FindElement(By.CssSelector("a[class='header__menulink--megamenu js-menulink'][href='/en-us/solutions']"));
            private IWebElement _buisnessValueSectionBarItem => _driver.FindElement(By.CssSelector("a[class='header__menulink--megamenu js-menulink'][href='/en-us/business-value']"));
            private IWebElement _servicesSectionBarItem => _driver.FindElement(By.CssSelector("a[class='header__menulink--megamenu js-menulink'][href='/en-us/services']"));
            private IWebElement _industriesSectionBarItem => _driver.FindElement(By.CssSelector("a[class='header__menulink--megamenu js-menulink'][href='/en-us/industries']"));
            private IWebElement _moreSectionBarItem => _driver.FindElement(By.CssSelector("a[class='header__menulink--megamenu js-menulink'][href='/en-us/more']"));

            /// <summary>
            /// Opens Solutions menu by hovering mouse over it.
            /// </summary>
            /// <returns>Returns new object of Soultions Submenu</returns>
            public SolutionsSubmenu OpenSolutionsSectionSubmenu()
            {
                Actions action = new Actions(_driver);
                action.MoveToElement(_solutionsSectionBarItem).Perform();
                return new SolutionsSubmenu(_driver);
            }

            /// <summary>
            /// Opens Buisness Value menu by hovering mouse over it.
            /// </summary>
            /// <returns>Returns new object of Buisness Value Submenu</returns>
            public BuisnessValueSubmenu OpenBuisnessValueSubmenu()
            {
                Actions action = new Actions(_driver);
                action.MoveToElement(_buisnessValueSectionBarItem).Perform();
                return new BuisnessValueSubmenu(_driver);
            }

            /// <summary>
            /// Opens More menu by hovering mouse over it.
            /// </summary>
            /// <returns>Returns new object of More Submenu</returns>
            public MoreSubmenu OpenMoreSubmenu()
            {
                Actions action = new Actions(_driver);
                action.MoveToElement(_moreSectionBarItem).Perform();
                return new MoreSubmenu(_driver);
            }

            public class SolutionsSubmenu : AbstractBase
            {
                public SolutionsSubmenu(IWebDriver driver) : base(driver)
                {
                    // waiting untill menu will roll out
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                    wait.Until(ExpectedConditions.ElementIsVisible(_solutionOverviewItemBy));
                }

                // Solutions submenu items selectors:

                // By used in ctor in waiting for submenu to roll out
                private By _solutionOverviewItemBy => By.CssSelector(".header a[href='/en-us/solutions/solution-overview']");

                private IWebElement _solutionOverviewItem => _driver.FindElement(By.CssSelector(".header a[href='/en-us/solutions/solution-overview']"));
                private IWebElement _omadaIdentityItem => _driver.FindElement(By.CssSelector(".header a[href='/en-us/solutions/solution-overview/omada-identity']"));
                private IWebElement _omadaIdentityCloudItem => _driver.FindElement(By.CssSelector(".header a[href='/en-us/solutions/solution-overview/omada-identity-cloud']"));

                public SolutionOverviewPage OpenSolutionOverviewPage()
                {
                    _solutionOverviewItem.Click();
                    return new SolutionOverviewPage(_driver);
                }

                public OmadaIdentityPage OpenOmadaIdentityPage()
                {
                    _omadaIdentityItem.Click();
                    return new OmadaIdentityPage(_driver);
                }
            }

            public class BuisnessValueSubmenu : AbstractBase
            {
                public BuisnessValueSubmenu(IWebDriver driver) : base(driver)
                {
                    // waiting untill menu will roll out
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                    wait.Until(ExpectedConditions.ElementIsVisible(_securityItemBy));
                }

                // Buisness Value sub items selectors:

                // By used in ctor in waiting for submenu to roll out
                private By _securityItemBy => By.CssSelector(".header a[href='/en-us/business-value/security']");

                private IWebElement _securityItem => _driver.FindElement(By.CssSelector(".header a[href='/en-us/business-value/security']"));
                private IWebElement _identityLifecycleManagementItem => _driver.FindElement(By.CssSelector(".header a[href='/en-us/business-value/security/identity-lifecycle-management']"));
                private IWebElement _privilegedAccessManagementItem => _driver.FindElement(By.CssSelector(".header a[href='/en-us/business-value/security/privileged-access-management']"));
                private IWebElement _riskAssessmentItem => _driver.FindElement(By.CssSelector(".header a[href='/en-us/business-value/security/risk-assessment']"));
                private IWebElement _segregationOfDutiesItem => _driver.FindElement(By.CssSelector(".header a[href='/en-us/business-value/security/segregation-of-duties-(sod)']"));
                private IWebElement _policyAndRoleManagementItem => _driver.FindElement(By.CssSelector(".header a[href='/en-us/business-value/security/policy-and-role-management']"));
                private IWebElement _reconciliationItem => _driver.FindElement(By.CssSelector(".header a[href='/en-us/business-value/security/reconciliation']"));
            }

            public class MoreSubmenu : AbstractBase
            {
                public MoreSubmenu(IWebDriver driver) : base(driver)
                {
                    // waiting untill menu will roll out
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                    wait.Until(ExpectedConditions.ElementIsVisible(_byOmadaPartnerProgramItem));
                }

                private By _byOmadaPartnerProgramItem => By.CssSelector("a[class='header__sublink--megamenu'][href='/en-us/more/omada-partner-program']");

                private IWebElement _omadaPartnerProgramItem => _driver.FindElement(By.CssSelector("a[class='header__sublink--megamenu'][href='/en-us/more/omada-partner-program']"));
                private IWebElement _jobsItem => _driver.FindElement(By.CssSelector("a[class='header__menulink--submenu'][href='/en-us/more/career/jobs']"));

                public JobsPage OpenJobsPage()
                {
                    _jobsItem.Click();
                    return new JobsPage(_driver);
                }

            }
        }
    }
}
