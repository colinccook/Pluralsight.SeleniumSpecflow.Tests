Feature: Weather
	In order to buy nice things today
	As a shopper who is concerned with convenient shopping
	I want to check the weather so I can shop dry

Scenario: Weather page direct when place name is unique
	Given I am on the standard BBC weather screen
	When I enter a search term of Middlesex
	Then I should see the weather summary page of Middlesex

Scenario: Choose from places with same name
	Given I am on the standard BBC weather screen
	When I enter a search term of Norwich
	Then I should see a list of places around the world called Norwich

Scenario: Weather summary for search with multiple places
	Given I am on the standard BBC weather screen
	When I enter a search term of Norwich
		And I select the first search result
	Then I should see the weather summary page of Norwich
	
