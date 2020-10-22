using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmadaWebsiteTests.PageObjects.Base
{
    // Base for all the object-oriented objects on page that require access to the driver.
    public abstract class AbstractBase
    {
        protected IWebDriver _driver;

        public AbstractBase(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
