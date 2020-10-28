using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

        [AfterScenario("file_downloading", Order = 1)]
        public void CleanupAfterdownloadingfile()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/Downloads");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            driver?.Dispose();
        }

        private IWebDriver GetWebDriver()
        {
            var envVariable = Environment.GetEnvironmentVariable("Test_Browser");
            var value = Environment.GetEnvironmentVariable("Test_Browser", EnvironmentVariableTarget.User);

            string filesDowloadPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Downloads";
            //_objectContainer.RegisterInstanceAs<string>(filesDowloadPath);  // simple type couldn't be resolved through context injection.

            switch (envVariable)
            {
                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("download.default_directory", filesDowloadPath);
                    return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions, TimeSpan.FromSeconds(15));
                case "Firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.SetPreference("browser.download.folderList", 2);
                    firefoxOptions.SetPreference("browser.download.dir", filesDowloadPath);
                    firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf");
                    firefoxOptions.SetPreference("pdfjs.enabledCache.state", false); // new line that doesn't change shit
                    return new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), firefoxOptions, TimeSpan.FromSeconds(15));
                case string browser: 
                    throw new NotSupportedException($"{browser} is not a supported browser");
                default: 
                    throw new NotSupportedException("not supported browser: <null>");
            }
        }
    }
}
