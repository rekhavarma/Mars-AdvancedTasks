Feature: Skills
	User Should be able to Add,Update and Delete Skills Details

@mytag
Scenario: Add Skills
	Given The User Clicks on Skills Tab
	When the user Adds the New Skills details and Clicks on Add button
	Then the User should see the new Skills in his profile


Scenario: Edit Skills
	Given The User is on Skills Tab
	When the user  Edits the Skills details and click on update button
	Then the Skills Details should be Updated and should be seen by User


Scenario: Delete Skills
	Given The User is on Skills Tab
	When the user deletes the Skills
	Then the Skills details should be deleted.