Feature: BBCHeaderLink
As a BBC User
I want to check all my header links 
so that my customers can see those pages 
@BBCHeaderlink
Scenario Outline: Verify Header links are working
	Given I navigate to BBC
	When I click on <headerlink> 
	Then I can see <headerlink> page 
	Examples: 
	| headerlink |
	| News       |
	| Sport		 |
	| Weather    |
	