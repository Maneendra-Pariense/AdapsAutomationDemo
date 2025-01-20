@chrome
Feature: Validate the functionality of Windows or Tabs

A short summary of the feature

#Background: 
#	Given User clicks on skip register button

@tag1 @reg
Scenario: Windows Tabbed Test Validation
	Given User clicks on skip register button
	When User should click on Menu "SwitchTo" and then "Windows"
	Then User should see "Frames & windows" screen
	Then User clicks on the Tab "#Tabbed"
	Then User should click "Tabbed" button
	Then User should see 2 windows
	Then User should switch to windows
	Then User should see new window with title "Selenium"

Scenario: Windows separate Test Validation
	Given User clicks on skip register button
	When User should click on Menu "SwitchTo" and then "Windows"
	Then User should see "Frames & windows" screen
	Then User clicks on the Tab "#Seperate"

Scenario: Windows multiple Test Validation
	Given User clicks on skip register button
	When User should click on Menu "SwitchTo" and then "Windows"
	Then User should see "Frames & windows" screen
	Then User clicks on the Tab "#Multiple"


Scenario: DatePicker test with single data set 1
	Given User clicks on skip register button
	When User should click on Menu "Widgetsss" and then " Datepicker "		
		And User selects the year 2025 month 01 and day 10

Scenario: DatePicker test with single data set 2
	Given User clicks on skip register button
	When User should click on Menu "Widgets" and then " Datepicker "
		And User selects the year 2025 month 01 and day 18

Scenario Outline: DatePicker test with different data
	Given User clicks on skip register button
	When User should click on Menu "Widgets" and then " Datepicker "
		And User selects the year <year> month <month> and day <day>

	Examples: 
	| year | month | day |
	| 2025 | 01    | 10  |
	| 2025 | 01    | 18  |

Scenario: Accessing the current example 

	When I use examples in my scenario
	Then the examples are available in ScenarioInfo 

	Examples:
	| Sport      | TeamSize |
	| Soccer     | 11       |
	| Basketball | 6        |

Scenario: Data table Example
	Given User clicks on skip register button
	And User navigates to the screen "WebTable"
	Then User should see following headers in the grid
	| headers    |
	| Email      |
	| First Name |
	| Gender     |
	| Last Name  |
	| Phone      |
	| Action     |

Scenario Outline: Validate Menu Navigations	
	Given User clicks on skip register button
	When User should click on Menu "<MainMenu>" and then "<SubMenu>"
	Then user should see the "<title>" screen title
	Examples: 
	| MainMenu | SubMenu | title            |
	| SwitchTo | Alerts  | Alerts           |
	| SwitchTo | Windows | Frames & windows |


		

