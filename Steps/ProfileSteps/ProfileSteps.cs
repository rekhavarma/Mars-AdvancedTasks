using MarsQA_1.Pages;
using MArsQASpecflow.SpecflowPages.Utils;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature.ProfileFeatures
{
    [Binding]
    public class ProfileSteps
    {
        ProfilePage page = new ProfilePage();

        [Given(@"User is on Profile Tab")]
        public void GivenUserIsOnProfileTab()
        {
            page.ClickProTab();
        }

        [Given(@"User Clicks on Availabiltytimelink")]
        public void GivenUserClicksOnAvailabiltytimelink()
        {
            page.AvailabiTimeLnk();
        }

        [Then(@"Choose one option from the dropdown\.")]
        public void ThenChooseOneOptionFromTheDropdown_()
        {
            page.AvailableType();
        }

        [Given(@"User Clicks on AvailabiltyHourlink")]
        public void GivenUserClicksOnAvailabiltyHourlink()
        {
            page.AvailabiHourLnk();
        }

        [Then(@"Choose one hour option from the dropdown\.")]
        public void ThenChooseOneHourOptionFromTheDropdown_()
        {
            page.AvailabilyHour();
        }


        [Then(@"Choose one Target option from the dropdown\.")]
        public void ThenChooseOneTargetOptionFromTheDropdown_()
        {
            page.AvailabilityTargt();
        }


        [Given(@"User Clicks on EarnTargetlink")]
        public void GivenUserClicksOnEarnTargetlink()
        {
            page.AvailabiTargetLnk();
        }

        [Given(@"User Clicks on Descriptiontab")]
        public void GivenUserClicksOnDescriptiontab()
        {
            page.AvailabiDesLnk();
        }

        [Given(@"User adds Description text")]
        public void GivenUserAddsDescriptionText()
        {
            page.AvailableDescrip();
        }

        [Then(@"Savethe description and Verify the details")]
        public void ThenSavetheDescriptionAndVerifyTheDetails()
        {
            page.AvailableDescripsave();
        }

        [Given(@"the user Clicks on User tab and changepassword link")]
        public void GivenTheUserClicksOnUserTabAndChangepasswordLink()
        {
            page.ChangePasswordtab();
        }
        
        [Given(@"the user inputs current password,new password and confirmpassword")]
        public void GivenTheUserInputsCurrentPasswordNewPasswordAndConfirmpassword()
        {
            page.ChangePassword();
        }
        
        [Given(@"Clicks on save button the details are saved")]
        public void GivenClicksOnSaveButtonTheDetailsAreSaved()
        {
            page.SaveBtn();
        }

        
        [Given(@"the user Clicks on Chat tab Chat screen opens")]
        public void GivenTheUserClicksOnChatTabChatScreenOpens()
        {
            page.Chat();
        }
        
        [When(@"the user inputs name in search input box")]
        public void WhenTheUserInputsNameInSearchInputBox()
        {
            page.Chatsearch();
        }
        
        
        [Then(@"Chats between the input name and user should be visible")]
        public void ThenChatsBetweenTheInputNameAndUserShouldBeVisible()
        {
            page.ChatsearchVisible();
        }
        
        [Then(@"to send message add message in input box")]
        public void ThenToSendMessageAddMessageInInputBox()
        {
            page.ChatMessage();
        }
        
        [Then(@"Clicks on send button")]
        public void ThenClicksOnSendButton()
        {
            page.ChatSendbtn();
        }
    }
}
