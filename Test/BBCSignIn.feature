Feature: BBCSignIn

@BBCSignIn
Scenario: Verify Sign in Successfully
	Given I navigate to BBC Website
	When I click on Account link
	And I enter my username and password
	And I click signin
	Then I am able to signin successfully