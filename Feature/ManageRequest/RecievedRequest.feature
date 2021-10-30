Feature: RecievedRequest
	Manage Receive Request

Scenario: Check Accept button on Manage Request page
	Given the User Clicks on Manage Request
	When the User clicks on the received request menu option
	And the User Accepts the new request
	Then the User should see the Accepted status on the request status


Scenario: Check Complete button on Manage Request page
	Given the User has received a new request
	When the User clicks on the received request menu option
	And the User Accepts the new request
	And the User clicks on the Complete button.
	


Scenario: Check Decline request on Manage Request page
	Given the User has receives a new request
	When the User clicks on the received request menu option
	And the User Declines the new request
	Then the User should see the Declined status on the request status
