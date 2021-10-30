Feature: certification
	User Should be able to Add,Update and Delete Ceritification Details . 

@mytag
Scenario: Add Certificate
	Given The User Clicks on Certificate Tab
	When the user Adds the New Certificate details and Clicks on Add button
	Then the User should see the new Certificate in his profile


Scenario: Edit Certificate
	Given The User is on Certificate Tab
	When the user  Edits the Certificate details and click on update button
	Then the Details should be Updated and should be seen by User


Scenario: Delete Certificate
	Given The User is on Certification Tab
	When the user deletes the Certificate
	Then the Certificate details should be deleted.