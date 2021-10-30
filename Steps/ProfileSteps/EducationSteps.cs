using MarsQA_1.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class EducationSteps
   
    {
        Education education = new Education();

        [Given(@"The User Clicks on Education Tab")]
        public void GivenTheUserClicksOnEducationTab()
        {
            education.EduTab();
        }
        
        [Given(@"The User is on Education Tab")]
        public void GivenTheUserIsOnEducationTab()
        {
            education.EduTab();
        }
        
        [When(@"the user Adds the New Education details and Clicks on Add button")]
        public void WhenTheUserAddsTheNewEducationDetailsAndClicksOnAddButton()
        {
            education.AddEducation();
        }
        
        [When(@"the user Clicks on Add button then education details should be added")]
        public void WhenTheUserClicksOnAddButtonThenEducationDetailsShouldBeAdded()
        {
            education.ValidateEducation();
        }
        
        [When(@"the user  Edits the Education details and click on update button")]
        public void WhenTheUserEditsTheEducationDetailsAndClickOnUpdateButton()
        {
            education.UpdateLanguage();
        }
        
        [When(@"the user deletes the Education")]
        public void WhenTheUserDeletesTheEducation()
        {
            education.DeleteEducation();
        }
        
        [Then(@"the Education Details should be Updated and should be seen by User")]
        public void ThenTheEducationDetailsShouldBeUpdatedAndShouldBeSeenByUser()
        {
            education.ValidateUpdatedEducation();
        }
        
        [Then(@"the Education details should be deleted\.")]
        public void ThenTheEducationDetailsShouldBeDeleted_()
        {
            education.ValidateDeleteEducation();
        }
    }
}
