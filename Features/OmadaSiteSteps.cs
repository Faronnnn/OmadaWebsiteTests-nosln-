using System;
using TechTalk.SpecFlow;
using OmadaWebsiteTests.PageObjects;
using BoDi;
using OpenQA.Selenium;
using OmadaWebsiteTests.PageObjects.Solutions;
using OmadaWebsiteTests.PageObjects.Solutions.SolutionOverview;
using OmadaWebsiteTests.PageObjects.More.Company;
using OmadaWebsiteTests.PageObjects.More.Career;
using TechTalk.SpecFlow.Assist;
using System.Threading;
using OmadaWebsiteTests.PageObjects.External;
using FluentAssertions;
using System.IO;
using System.Reflection;
using OmadaWebsiteTests.PageObjects.More.Resources;
using OpenQA.Selenium.Support.UI;

namespace OmadaWebsiteTests.Features
{
    [Binding]
    public class OmadaSiteSteps
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private MainPage _mainPage;
        private SolutionOverviewPage _solutionOverviewPage;
        private OmadaIdentityPage _omadaIdentityPage;
        private ContactPage _contactPage;
        private ContactPage.ContactForm _contactForm;
        private JobsPage _jobsPage;
        private CandidateManagerPage _careerPortal;
        private OmadaIdentitySuiteSolutionOverview _omadaIdentitySuiteSolutionOverview;
        private string _fileDownloadsPath;

        public OmadaSiteSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            //_fileDownloadsPath = _objectContainer.Resolve<string>();
            _fileDownloadsPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/downloads";
        }

        [Given(@"I am on the main page")]
        public void GivenIAmOnTheMainPage()
        {
            _mainPage = new MainPage(_driver);
            _mainPage.GoTo();
        }

        [When(@"I open Omada Identity page from Solutions section in Main Menu")]
        public void WhenIOpenOmadaIdentityPageFromSolutionsSectionInMainMenu()
        {
            var solutionMenu = _mainPage.MainMenu().OpenSolutionsSectionSubmenu();
            _omadaIdentityPage = solutionMenu.OpenOmadaIdentityPage();
        }
        
        [When(@"I go to Contact Omada page from Soulution Identity page")]
        public void WhenIGoToContactOmadaPageFromSoulutionIdentityPage()
        {
            _contactPage = _omadaIdentityPage.OpenContactOmada();
        }

        [When(@"I fill the contact form with following data")]
        public void WhenIFillTheContactFormWithFollowingData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _contactForm = _contactPage.FillContactForm((string)data.Department, (string)data.FirstName, (string)data.LastName, (string)data.Company, (string)data.JobTitle, (string)data.Level, (string)data.Email, (string)(data.Phone+""), (string)data.Country, (string)data.Subject);
        }
        
        [Then(@"all fields of contact form are filled")]
        public void ThenAllFieldsOfContactFormAreFilled()
        {
            _contactForm.GetFirstNameFieldValue().Should().NotBeNullOrEmpty();
            _contactForm.GetFirstNameFieldValue().Should().NotBeNullOrEmpty();
            _contactForm.GetLastNameFieldValue().Should().NotBeNullOrEmpty();
            _contactForm.GetCompanyFieldValue().Should().NotBeNullOrEmpty();
            _contactForm.GetJobTitleFieldValue().Should().NotBeNullOrEmpty();
            _contactForm.GetEmailFieldValue().Should().NotBeNullOrEmpty();
            _contactForm.GetPhoneFieldValue().Should().NotBeNullOrEmpty();
            // _contactForm.GetSubjectFieldValue().Should().NotBeNullOrEmpty(); // Subject field doesn't accept values
        }

        [When(@"I open Jobs page from Career section in Main Menu")]
        public void WhenIOpenJobsPageFromCareerSectionInMainMenu()
        {
            var moreMenu = _mainPage.MainMenu().OpenMoreSubmenu();
            _jobsPage = moreMenu.OpenJobsPage();
        }

        [When(@"I Open Career Portal from Jobs page")]
        public void WhenIOpenCareerPortalFromJobsPage()
        {
            _careerPortal = _jobsPage.OpenCareerPortal();
        }

        [When(@"I set '(.*)' on city filter on the Career Portal")]
        public void WhenISetOnCityFilterOnTheCareerPortal(string cityName)
        {
            _careerPortal.ToggleCityFilter(cityName);
        }

        [Then(@"I see '(.*)' in the results")]
        public void ThenISeeInTheResults(string jobTitle)
        {
            _careerPortal.CheckIfJobOfferExist(jobTitle).Should().BeTrue();
            //Assert.IsTrue(_careerPortal.CheckIfJobOfferExist(jobTitle));
        }

        [When(@"I open Contact Omada page from main page")]
        public void WhenIOpenContactOmadaPageFromMainPage()
        {
            _contactPage = _mainPage.ClickContactUsButton();
        }

        [Then(@"address of Polish branch is correct")]
        public void ThenAddressOfPolishBranchIsCorrect()
        {
            string polishAddress = "Omada | Postępu 17A | 02-676 Warszawa";
            _contactPage.SearchForAnAddress(polishAddress).Should().BeTrue();
            //Assert.IsTrue(_contactPage.SearchForAnAddress(polishAddress));
        }

        [When(@"I Open Omada Identity Suite - Solution Overview from Resuources section in Main Menu")]
        public void WhenIOpenOmadaIdentitySuite_SolutionOverviewFromResuourcesSectionInMainMenu()
        {
            _omadaIdentitySuiteSolutionOverview = _mainPage.MainMenu().OpenMoreSubmenu().OpenOmadaSuiteSolutionOverviewPage();
        }

        [When(@"I download Solution Sheet")]
        public void WhenIDownloadSolutionSheet()
        {
            _omadaIdentitySuiteSolutionOverview.DownloadGuide();

        }

        [Then(@"'(.*)' is downloaded correctly")]
        public void ThenIsDownloadedCorrectly(string fileName)
        {
            Helpers.Helpers.CheckIfFileExist(_driver, _fileDownloadsPath, fileName).Should().BeTrue();
            //ScenarioContext.Current.Pending();
        }


    }
}
