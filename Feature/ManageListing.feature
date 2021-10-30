Feature: ManageListing
	Edit, view and Delete shareskill page from manage listing page

@mytag
Scenario: Edit Skill In Manage Listing Page
	Given User have Navigated to Manage Listing Page
	And  User Press Edit Icon which Navigates to Share Skill Page   
	And  User edit the fields and Click on Save Button
	Then Click on View Icon in Manage Listing page to see the changes.

	Scenario:Delete Skill In Manage Listing Page
	Given User is on  the Manage Listing Page
	And User Clicks  on Delete Icon 
	Then User should get an Alert for deletion 
	And User should be able to Delete the Skill