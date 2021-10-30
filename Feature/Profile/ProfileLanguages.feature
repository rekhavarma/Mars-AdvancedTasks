Feature: ProfileLanguages
	User Should be able to Add, Update and Delete Language Details
@mytag
Scenario: Add Language
	Given The User Clicks on Language Tab
	When the user Adds the New Language details and Clicks on Add button
	Then the User should see the new Language in his profile

Scenario: Edit Language
	Given The User is on Language Tab
	When the user  Edits the Language details and click on update button
	Then the Language Details should be Updated and should be seen by User


Scenario: Delete Language
	Given The User is on Language Tab
	When the user deletes the Language
	Then the Language details should be deleted.