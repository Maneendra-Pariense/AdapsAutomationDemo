@firefox
Feature: Calculator

@mytag
Scenario: Add two numbers
	Given the first number is 2000
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
	Given User clicks on skip register button