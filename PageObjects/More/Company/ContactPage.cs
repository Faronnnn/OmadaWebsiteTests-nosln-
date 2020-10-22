using OmadaWebsiteTests.PageObjects.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OmadaWebsiteTests.Helpers;

namespace OmadaWebsiteTests.PageObjects.More.Company
{
    public class ContactPage : AbstractPage
    {
        public ContactPage(IWebDriver driver) : base(driver)
        {
            _address = "/en-us/more/company/contact";
        }

        private IReadOnlyCollection<IWebElement> _companyAdresses => _driver.FindElements(By.CssSelector(".form__text p"));

        public bool SearchForAnAddress(string addressToSearch)
        {
            foreach(var item in _companyAdresses)
            {
                if (item.Text.Contains(addressToSearch))
                    return true;
            }
            return false;
        }

        public ContactForm FillContactForm(string department, string firstName, string lastName, string company, string jobTitle, string level, string email, string phone, string country, string subject)
        {
            var form = new ContactForm(_driver);
            form.Fill(department, firstName, lastName, company, jobTitle, level, email, phone, country, subject);
            return form;
        }

        public class ContactForm : AbstractBase
        {
            internal ContactForm(IWebDriver driver) : base(driver) { }
            public void Fill(string department, string firstName, string lastName, string company, string jobTitle, string level, string email, string phone, string country, string subject)
            {
                // The contact form is loaded in iframe so in order to get to the fields, first I need to switch to this iframe.
                _driver.SwitchTo().Frame(_driver.FindElement(By.CssSelector("iframe[src='https://go.omada.net/l/581103/2018-08-31/3k5pnx']")));
                SetDepartmentField(department);
                SetFirstNameField(firstName);
                SetLastNameField(lastName);
                SetCompanyField(company);
                SetJobTitleField(jobTitle);
                SetLevelField(level);
                SetEmailField(email);
                SetPhoneField(phone);
                SetCountryField(country);
                SetSubjectField(subject);
                AcceptOmadaPrivacyPolicy();
                
            }

            private IWebElement _departmentField => _driver.FindElement(By.Name("581103_91599pi_581103_91599"));
            private By _byOfFirstNameField => By.Id("581103_89027pi_581103_89027");
            private IWebElement _firstNameField => _driver.FindElement(_byOfFirstNameField);
            private IWebElement _lastNameField => _driver.FindElement(By.Id("581103_89029pi_581103_89029"));
            private IWebElement _companyField => _driver.FindElement(By.Id("581103_89031pi_581103_89031"));
            private IWebElement _jobTitleField => _driver.FindElement(By.Id("581103_89035pi_581103_89035"));
            private IWebElement _levelField => _driver.FindElement(By.Id("581103_89183pi_581103_89183"));
            private By _byOfEmailField => By.Id("581103_89033pi_581103_89033");
            private IWebElement _emailField => _driver.FindElement(_byOfEmailField);
            private IWebElement _phoneField => _driver.FindElement(By.Id("581103_92509pi_581103_92509"));
            private IWebElement _countryField => _driver.FindElement(By.Id("581103_89179pi_581103_89179"));
            private By _byOfSubjectField => By.Id("581103_91683pi_581103_91683");
            private IWebElement _subjectField => _driver.FindElement(_byOfSubjectField);
            private IWebElement _acceptOmadaPrivacyPolicyRadioButton => _driver.FindElement(By.CssSelector("label[for='581103_89037pi_581103_89037_1093641_1093641']"));
            private IWebElement _submitButton => _driver.FindElement(By.CssSelector("input[type='submit']"));

            public void SetDepartmentField(string value)
            {
                _departmentField.SendKeys(value);
                _departmentField.SendKeys(Keys.Enter);
                Helpers.Helpers.Wait(_driver, _byOfFirstNameField);
            }

            [Obsolete("Using this method returns whole list of options instead of selected one.")]
            public string GetDepartmentFieldValue()
            {
                return _departmentField.GetAttribute("Value");
            }

            public void SetFirstNameField(string value)
            {
                _firstNameField.SendKeys(value);
            }

            public string GetFirstNameFieldValue()
            {
                return _firstNameField.GetAttribute("Value");
            }

            public void SetLastNameField(string value)
            {
                _lastNameField.SendKeys(value);
            }

            public string GetLastNameFieldValue()
            {
                return _lastNameField.GetAttribute("Value");
            }

            public void SetCompanyField(string value)
            {
                _companyField.SendKeys(value);
            }

            public string GetCompanyFieldValue()
            {
                return _companyField.GetAttribute("Value");
            }

            public void SetJobTitleField(string value)
            {
                _jobTitleField.SendKeys(value);
            }

            public string GetJobTitleFieldValue()
            {
                return _jobTitleField.GetAttribute("Value");
            }

            public void SetLevelField(string value)
            {
                _levelField.SendKeys(value);
                _levelField.SendKeys(Keys.Enter);
                Helpers.Helpers.Wait(_driver, _byOfEmailField);
            }

            [Obsolete("Using this method returns whole list of options instead of selected one.")]
            public string GetLevelFieldValue()
            {
                return _levelField.GetAttribute("Value");
            }

            public void SetEmailField(string value)
            {
                _emailField.SendKeys(value);
            }

            public string GetEmailFieldValue()
            {
                return _emailField.GetAttribute("Value");
            }

            public void SetPhoneField(string value)
            {
                _phoneField.SendKeys(value);
            }

            public string GetPhoneFieldValue()
            {
                return _phoneField.GetAttribute("Value");
            }

            public void SetCountryField(string value)
            {
                _countryField.SendKeys(value);
                _companyField.SendKeys(Keys.Enter);
                Helpers.Helpers.Wait(_driver, _byOfSubjectField);
            }

            [Obsolete("Using this method returns whole list of options instead of selected one.")]
            public string GetCountryFieldValue()
            {
                return _countryField.GetAttribute("Value");
            }
            
            public void SetSubjectField(string value)
            {
                // System.Threading.Thread.Sleep(2000); // For some reason the Subject field doesn't recives value when done without Sleep.
                _subjectField.SendKeys(value);
            }

            public string GetSubjectFieldValue()
            {
                return _subjectField.GetAttribute("Value");
            }

            public void AcceptOmadaPrivacyPolicy()
            {
                _acceptOmadaPrivacyPolicyRadioButton.Click();
            }
        }
    }
}
