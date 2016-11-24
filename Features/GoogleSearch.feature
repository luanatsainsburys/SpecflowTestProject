Feature: GoogleSearch
	In order to be able to do online research
	As an idiot
	I want to be able to search google

@Browser:Chrome
Scenario: Google search for Execute Automation
	Given I have navigated to Google page
	And I see the Google page fully loaded
	When I type search keywords as
	| Keyword            |
	| Execute automation |
	Then I should see the result for keword
	| Keyword            |
	| Execute automation |
