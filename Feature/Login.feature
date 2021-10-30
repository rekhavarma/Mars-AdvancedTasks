Feature: Login
	    In order to add my Profile Details
        As a Seller I want to be able to login to profile 
       

@mytag
Scenario: When valid credentials are used should result in successfull login
Given I login to the Website
And I click signIn button
When I enter valid credentials
Then I should be logged in successfully

Examples:
| username                  | password    |
| rekhavarma.n@gmail.com | rekha123 |
