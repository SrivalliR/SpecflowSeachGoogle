Feature: SearchGoogle

@mytag
Scenario Outline: Search a string in Google
	Given I navigate to Google page
	And Enter <searchstring> in the searchbox
	| <searchstring> |
	| searchstring    |
	When Press search button
	Then the result page should be displayed

Examples:
	| searchstring |
	| Selenium     |
	| BDD          |
	| NUNIT        |
