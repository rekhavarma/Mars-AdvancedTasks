Feature: ShareSkill
	Add skills onto Shareskill Page

@mytag
    Scenario: Add Skill In the Share Skill Page
	Given User Click on Share Skill Button fron Profile Page
	And  User enter the entire Required Fields
	When User Click on Save Button to Add the Skills
	Then Check whether New skills are created sucessfully
