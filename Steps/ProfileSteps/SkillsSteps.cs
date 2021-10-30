using MarsQA_1.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class SkillsSteps
    {
        ProfileSkills skills = new ProfileSkills();

        [Given(@"The User Clicks on Skills Tab")]
        public void GivenTheUserClicksOnSkillsTab()
        {
            skills.SkillsTab();
        }
       
        [When(@"the user Adds the New Skills details and Clicks on Add button")]
        public void WhenTheUserAddsTheNewSkillsDetailsAndClicksOnAddButton()
        {
            skills.AddSkill();
        }
        
        [Then(@"the User should see the new Skills in his profile")]
        public void ThenTheUserShouldSeeTheNewSkillsInHisProfile()
        {
            skills.ValidateAddSkill();
        } 
        
        [Given(@"The User is on Skills Tab")]
        public void GivenTheUserIsOnSkillsTab()
        {
            skills.SkillsTab();
        }
        [When(@"the user  Edits the Skills details and click on update button")]
        public void WhenTheUserEditsTheSkillsDetailsAndClickOnUpdateButton()
        {
            skills.UpdateSkill();
        }

        [Then(@"the Skills Details should be Updated and should be seen by User")]
        public void ThenTheSkillsDetailsShouldBeUpdatedAndShouldBeSeenByUser()
        {
            skills.ValidateUpdateSkill();
        }

        [When(@"the user deletes the Skills")]
        public void WhenTheUserDeletesTheSkills()
        {
            skills.DeleteSkill();
        }

        [Then(@"the Skills details should be deleted\.")]
        public void ThenTheSkillsDetailsShouldBeDeleted_()
        {
            skills.ValidateDelSkill();
        }
    }
}
