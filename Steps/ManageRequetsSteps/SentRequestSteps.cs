using MarsQA_1.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature.ManageRequest
{
    [Binding]
    public class SentRequestSteps
    {
        [Binding]
        public class SentRequestStep
        {

            SentRequest SdRqst = new SentRequest();
            RecievedRequest RcRqst = new RecievedRequest();

            [Given(@"The User Clicks ManageRequest tab")]
            public void GivenTheUserClicksManageRequestTab()
            {
                RcRqst.ManageRequest();
            }

            [Given(@"Select SentRequest DropDown")]
            public void GivenSelectSentRequestDropDown()
            {
                SdRqst.SenRequest();
            }

            [Then(@"If the Sender has not Accepted the Status will be pending\.")]
            public void ThenIfTheSenderHasNotAcceptedTheStatusWillBePending_()
            {
                SdRqst.PendStatus();
            }

            [Given(@"if User wants to withdraw, click on withdraw button")]
            public void GivenIfUserWantsToWithdrawClickOnWithdrawButton()
            {
                SdRqst.WithdrawSentRequest();
            }

            [Then(@"the Status should be Withdrawn")]
            public void ThenTheStatusShouldBeWithdrawn()
            {
                SdRqst.WithdrStatus();
            }
            [Given(@"if the Status is Accepted the Request is Accepted by Receiver")]
            public void GivenIfTheStatusIsAcceptedTheRequestIsAcceptedByReceiver()
            {
                SdRqst.Accepted();
            }

            [Given(@"Completed Button will be Visible")]
            public void GivenCompletedButtonWillBeVisible()
            {
                SdRqst.Cmpletebtn();
            }


            [Then(@"Click on Completed Button")]
            public void ThenClickOnCompletedButton()
            {
                SdRqst.Completed();
            }
            [Given(@"if the Status is Completed")]
            public void GivenIfTheStatusIsCompleted()
            {
                SdRqst.CompleteStatus();
            }

            [Then(@"Click on Review Button")]
            public void ThenClickOnReviewButton()
            {
                SdRqst.ReviewBtn();
            }

            [Then(@"Add Review Text and Ratings and Save\.")]
            public void ThenAddReviewTextAndRatingsAndSave_()
            {
                SdRqst.Review();
            }

            [Given(@"if the Status is Declined the Request is Declined")]
            public void GivenIfTheStatusIsDeclinedTheRequestIsDeclined()
            {
                SdRqst.DeclinStatus();
            }


        }
    }
}
