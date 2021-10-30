using MarsQA_1.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class ManageListingSteps
    {
        ManageListing list = new ManageListing();

        [Given(@"User have Navigated to Manage Listing Page")]
        public void GivenUserHaveNavigatedToManageListingPage()
        {
            list.Managelisting();
        }
        
        [Given(@"User is on  the Manage Listing Page")]
        public void GivenUserIsOnTheManageListingPage()
        {
            list.ValidateManageListingPage();
        }
        
        [Given(@"User Clicks  on Delete Icon")]
        public void GivenUserClicksOnDeleteIcon()
        {
            list.DeleteShareSkill();
        }

        [Given(@"User Press Edit Icon which Navigates to Share Skill Page")]
        public void GivenUserPressEditIconWhichNavigatesToShareSkillPage()
        {
            list.EditshareSkill();
        }

        [Given(@"User edit the fields and Click on Save Button")]
        public void GivenUserEditTheFieldsAndClickOnSaveButton()
        {
            list.savebutton();
        }
        
        [Then(@"Click on View Icon in Manage Listing page to see the changes\.")]
        public void ThenClickOnViewIconInManageListingPageToSeeTheChanges_()
        {
            list.ViewShareSkill();
        }
        
        [Then(@"User should get an Alert for deletion")]
        public void ThenUserShouldGetAnAlertForDeletion()
        {
            list.Alertmessage();
        }
        
        [Then(@"User should be able to Delete the Skill")]
        public void ThenUserShouldBeAbleToDeleteTheSkill()
        {
            list.ValidateDeleteListing();
        }
    }
}
