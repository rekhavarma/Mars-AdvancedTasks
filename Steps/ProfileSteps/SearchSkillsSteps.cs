using MarsQA_1.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature.Profile
{
    [Binding]
    public class SearchSkillsSteps
    {
        SearchSkills skills = new SearchSkills();
        
        [Given(@"the user is on Profile tab")]
        public void GivenTheUserIsOnProfileTab()
        {
            skills.ProfileTab();
        }
        
        [Given(@"the user inputs search key in search inputbox and click on searchicon")]
        public void GivenTheUserInputsSearchKeyInSearchInputboxAndClickOnSearchicon()
        {
            skills.Searchskills();
        }
        
        [When(@"the user input search key Refine search and click on searchicon")]
        public void WhenTheUserInputSearchKeyRefineSearchAndClickOnSearchicon()
        {
            skills.RefineSearchSkills();
        }
        
        [When(@"the user input search user key search user and click on searchicon")]
        public void WhenTheUserInputSearchUserKeySearchUserAndClickOnSearchicon()
        {
            skills.RefinesearchUser();
        }
        
        [When(@"add  any of the filters the filtered search should be displayed")]
        public void WhenAddAnyOfTheFiltersTheFilteredSearchShouldBeDisplayed()
        {
            skills.RefineFilterSearchSkills();
        }
        
        [Then(@"the refined search items should be Displayed")]
        public void ThenTheRefinedSearchItemsShouldBeDisplayed()
        {
            skills.RefineSearchVisible();
        }
    }
}
