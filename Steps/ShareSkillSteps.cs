using MarsQA_1.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class ShareSkillSteps
    {
        ShareSkills share = new ShareSkills();

        [Given(@"User Click on Share Skill Button fron Profile Page")]
        public void GivenUserClickOnShareSkillButtonFronProfilePage()
        {
            share.ShareSkillButton();
        }
        
        [Given(@"User enter the entire Required Fields")]
        public void GivenUserEnterTheEntireRequiredFields()
        {
            share.AddShareSkill();
        }
        
        [When(@"User Click on Save Button to Add the Skills")]
        public void WhenUserClickOnSaveButtonToAddTheSkills()
        {
            share.SaveButton();
        }
        
        [Then(@"Check whether New skills are created sucessfully")]
        public void ThenCheckWhetherNewSkillsAreCreatedSucessfully()
        {
            share.ValidateCreateListing();
        }
    }
}
