@reg
Feature: Validate the functionality of Windows or Tabs

A short summary of the feature

@tag1 @reg
Scenario: Windows Tabbed Test Validation
	Given User clicks on skip register button
	When User should click on Menu "SwitchTo" and then "Windows"
#	Then User should see "Windows" screen
	Then User clicks on the Tab "#Tabbed"

Scenario: Windows separate Test Validation
	Given User clicks on skip register button

Scenario: Windows multiple Test Validation
	Given User clicks on skip register button

Scenario Outline: DatePicker test with different data
	Given User clicks on skip register button
	When User should click on Menu "Widgets" and then " Datepicker "
	And User selects the year <year> month <month> and day <day>

	Examples: 
	| year | month | day |
	| 2025 | 01    | 10  |
	| 2025 | 01    | 18  |
	
