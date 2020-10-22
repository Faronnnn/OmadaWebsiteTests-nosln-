using NUnit.Framework.Constraints;
using OmadaWebsiteTests.PageObjects.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OmadaWebsiteTests.PageObjects.External
{
    /// <summary>
    /// Page that represents 
    /// </summary>
    public class CandidateManagerPage : AbstractBase
    {
        private string _address = "https://candidate.hr-manager.net/vacancies/list.aspx?customer=omada";

        public CandidateManagerPage(IWebDriver driver) :base(driver)
        {
            // Because this page opens in new card it is required to switch driver to this tab.
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        private IWebElement _cityFitlerCheckbox(string cityName) => _driver.FindElement(By.CssSelector($"input[class='rtChk_locationcascade1'][value='{cityName}']"));
        private IReadOnlyCollection<IWebElement> _jobPositionsTable => _driver.FindElements(By.CssSelector(".project-title.table_cell"));

        public void ToggleCityFilter(string cityName)
        {
            _cityFitlerCheckbox(cityName).Click();
        }

        public bool CheckIfJobOfferExist(string jobPosition)
        {
            foreach(var item in _jobPositionsTable)
            {
                if (item.Text.Contains(jobPosition))
                    return true;
            }
            return false;
        }

        //internal void SwitchToTab()
        //{
        //    _driver.Instance.Wait().;
        //    var newTab = WebDriver.Instance.Driver().WindowHandles[tabIndex];
        //    Instance.Driver().SwitchTo().Window(newTab);
        //    WebDriver.Instance.Wait(2);
        //}
    }
}
