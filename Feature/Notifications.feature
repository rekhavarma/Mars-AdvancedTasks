Feature: Notifications
	The features in the  Notification menu and Dashboard page

Scenario: Check if user is able to click on "Notification"
	Given the User is in Profile Page
	When User Clicks on the Notification button
	Then The Notification Page should be displayed

Scenario: Check if user is able to click on "Notification"->"Mark all as read"
	Given User Clicks on the Notification button
	When Clicks on the Mark all as read button
	Then The numbers of notification should be Cleared	

Scenario: Check if user is able to click on "Notification"->"See all"
	Given User Clicks on the Notification button
	When Clicks on the See all button
	Then The user should be able to navigate to the dashboard Page

Scenario: Check if user is able to click on "Load more"
	Given User Clicks on the Notification button
	And Clicks on the See all button
	When Clicks on the Load More button
	Then The Show Less button should be displayed	


Scenario: Check if user is able to click on "Show Less"
	Given User Clicks on the Notification button
	And Clicks on the See all button
	And Clicks on the Load More button
	When User Clicks on the Show Less button
	Then The Show Less button should be not displayed


Scenario: Check if user is able to Delete for single notification
	Given User Clicks on the Notification button
	And Clicks on the See all button
	And Ticks a notification Item
	When User Clicks on the Delete Selection icon
	Then The notification Item should be deleted


Scenario: Check if user is able to Delete for multiple notifications
	Given User Clicks on the Notification button
	And Clicks on the See all button
	And Ticks more than one notification items
	When User Click on the Delete Selection icon
	Then The notification Items should be deleted


Scenario: Check if user is able to delete all notifications
	Given User Clicks on the Notification button
	And Clicks on the See all button
	And  Clicks on Select All icon
	When User Clicks on the Delete Selection icon
	Then All of the notification items should be deleted

Scenario: Check if user is able to mark a single notification as read
	Given User Clicks on the Notification button
	And Clicks on the See all button
	And Ticks a notification item
	When User Clicks on Mark Selection as Read


Scenario: Check if user is able to mark multiple notifications as read
	Given User Clicks on the Notification button
	And Clicks on the See all button
	And  Clicks on Select All 
	When User Clicks on Mark Selection as Read
	

Scenario: Check if user is able to click on Select All
	Given User Clicks on the Notification button
	And Clicks on the See all button
	When Clicks on Select all
	Then All notifications should be selected


Scenario: Check if user is able to click on Unselect all when all notifications are selected
	Given User Clicks on the Notification button
	And Clicks on the See all button
	And Clicks on Select all
	When Clicks on Unselect all
	Then All notifications should be unselected
