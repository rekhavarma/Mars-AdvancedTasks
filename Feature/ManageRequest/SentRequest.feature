Feature: SentRequest
	Check the Withdraw and Pending Status of SentRequest
@mytag
Scenario:Check Sent Request Pending 
	Given The User Clicks ManageRequest tab 
	And Select SentRequest DropDown
	Then If the Sender has not Accepted the Status will be pending.

	Scenario:Check Sent Request Withdrawn
	Given The User Clicks ManageRequest tab 
	And Select SentRequest DropDown
	And if User wants to withdraw, click on withdraw button
	Then the Status should be Withdrawn

	Scenario:Check Sent Request Accepted
	Given The User Clicks ManageRequest tab 
	And Select SentRequest DropDown
	And if the Status is Accepted the Request is Accepted by Receiver
	And Completed Button will be Visible

	Scenario:Check Sent Request Completed
	Given The User Clicks ManageRequest tab 
	And Select SentRequest DropDown 
	And if the Status is Accepted the Request is Accepted by Receiver
	Then Click on Completed Button

	Scenario:Check Review in Sent Request
	Given The User Clicks ManageRequest tab 
	And Select SentRequest DropDown
	And if the Status is Completed 
	Then Click on Review Button 
	And Add Review Text and Ratings and Save.
	

	Scenario:Check Sent Request Declined
	Given The User Clicks ManageRequest tab 
	And Select SentRequest DropDown
	And if the Status is Declined the Request is Declined
	

	
	
