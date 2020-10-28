Feature: OmadaWebsiteTests
	Example of tests testing Omada Website responsiveness


@website @contact_form @Browser_Chrome
Scenario: Checking responsiveness of contact form fields
	Given I am on the main page
	When I open Omada Identity page from Solutions section in Main Menu
	And I go to Contact Omada page from Soulution Identity page
	And I fill the contact form with following data
	| Department | FirstName | LastName | Company | JobTitle | Level | Email         | Phone     | Country | Subject |
	| Sales      | Test      | Test     | Test    | Test     | VP    | test@test.com | 123456789 | Poland  | Test    |
	Then all fields of contact form are filled

@website @job_offers @Browser_Chrome
Scenario: Checking if jobs offers are accessible through website
	Given I am on the main page
	When I open Jobs page from Career section in Main Menu
	And I Open Career Portal from Jobs page
	And I set 'Warsaw' on city filter on the Career Portal
	Then I see 'Azure Cloud Automation Ninja' in the results

@website @company_address @Browser_Chrome @Browser_Firefox
Scenario: Checking if company address is up to date
	Given I am on the main page
	When I open Contact Omada page from main page
	Then address of Polish branch is correct

@website @file_downloading @Browser_Chrome @Browser_Firefox
Scenario: Downloading demo file
	Given I am on the main page
	When I Open Omada Identity Suite - Solution Overview from Resuources section in Main Menu
	And I download Solution Sheet
	Then 'Omada_Identity_Suite_Overview.pdf' is downloaded correctly