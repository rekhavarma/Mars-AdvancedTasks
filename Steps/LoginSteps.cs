using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class LoginSteps 
    {
       

        [Given(@"I login to the Website")]
        public void GivenILoginToTheWebsite()
        {
           
            MarsQA_1.Pages.SignIn.SigninStep();
        
        }


        [Given(@"I click signIn button")]
        public void GivenIClickSignInButton()
        {
           
        }
        
        [When(@"I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            
        }
        
        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            
        }
    }
}
