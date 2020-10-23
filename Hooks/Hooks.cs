﻿using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace OmadaWebsiteTests.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var webDriver = GetWebDriver();
            webDriver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<ChromeDriver>();
            driver?.Dispose();
        }

        private IWebDriver GetWebDriver()
        {
            var envVariable = Environment.GetEnvironmentVariable("Test_Browser");
            var value = Environment.GetEnvironmentVariable("Test_Browser", EnvironmentVariableTarget.User);


            IDictionary environmentVariables = Environment.GetEnvironmentVariables();

            
            switch (envVariable)
            {
                case "Chrome": return new ChromeDriver(); //{ Url = SeleniumBaseUrl };
                case "Firefox": return new FirefoxDriver(); //{ Url = SeleniumBaseUrl };
                case string browser: throw new NotSupportedException($"{browser} is not a supported browser");
                default: throw new NotSupportedException("not supported browser: <null>");
            }
        }
    }
}
