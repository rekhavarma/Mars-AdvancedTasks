using MarsQA_1.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature.ManageRequest
{
    [Binding]
    public class RecievedRequestSteps
    {
        RecievedRequest RcRqst = new RecievedRequest();

        [Given(@"the User Clicks on Manage Request")]
        public void GivenTheUserClicksOnManageRequest()
        {
            RcRqst.ManageRequest();
        }

        [When(@"the User clicks on the received request menu option")]
        public void WhenTheUserClicksOnTheReceivedRequestMenuOption()
        {
            RcRqst.RecRequest();
        }

        [When(@"the User Accepts the new request")]
        public void WhenTheUserAcceptsTheNewRequest()
        {
            RcRqst.RequestAccept();
        }
        [Then(@"the User should see the Accepted status on the request status")]
        public void ThenTheUserShouldSeeTheAcceptedStatusOnTheRequestStatus()
        {
            RcRqst.AcceptStatus();
        }

        [Given(@"the User has received a new request")]
        public void GivenTheUserHasReceivedANewRequest()
        {
            RcRqst.RecRequest();
        }
        [When(@"the User clicks on the Complete button\.")]
        public void WhenTheUserClicksOnTheCompleteButton_()
        {
            RcRqst.RequestCompleted();
        }

        [Given(@"the User has receives a new request")]
        public void GivenTheUserHasReceivesANewRequest()
        {
            RcRqst.RecRequest();
        }

        [When(@"the User Declines the new request")]
        public void WhenTheUserDeclinesTheNewRequest()
        {
            RcRqst.RequestDecline();
        }

        [Then(@"the User should see the Declined status on the request status")]
        public void ThenTheUserShouldSeeTheDeclinedStatusOnTheRequestStatus()
        {
            RcRqst.DeclineStatus();
        }


    }
}
