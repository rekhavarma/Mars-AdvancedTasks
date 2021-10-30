using MarsQA_1.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class CertificationSteps
    {
        Certification certificate = new Certification();

        [Given(@"The User Clicks on Certificate Tab")]
        public void GivenTheUserClicksOnCertificateTab()
        {
            certificate.CertiTab();
        }

        [Given(@"The User is on Certificate Tab")]
        public void GivenTheUserIsOnCertificateTab()
        {
            certificate.CertiTab();
        }


        [Given(@"The User is on Certification Tab")]
        public void GivenTheUserIsOnCertificationTab()
        {
            certificate.CertiTab();
        }


        [When(@"the user Adds the New Certificate details and Clicks on Add button")]
        public void WhenTheUserAddsTheNewCertificateDetailsAndClicksOnAddButton()
        {
            certificate.AddCertificate();
        }
        
        [When(@"the user  Edits the Certificate details and click on update button")]
        public void WhenTheUserEditsTheCertificateDetailsAndClickOnUpdateButton()
        {
            certificate.UpdateCertificate();
        }
        
        [When(@"the user deletes the Certificate")]
        public void WhenTheUserDeletesTheCertificate()
        {
            certificate.DeleteCertificate();
        }
        
        [Then(@"the User should see the new Certificate in his profile")]
        public void ThenTheUserShouldSeeTheNewCertificateInHisProfile()
        {
            certificate.ValidateAddCertificate();
        }
        
        [Then(@"the Details should be Updated and should be seen by User")]
        public void ThenTheDetailsShouldBeUpdatedAndShouldBeSeenByUser()
        {
            certificate.ValidateUpdateCertificate();
        }
        
        [Then(@"the Certificate details should be deleted\.")]
        public void ThenTheCertificateDetailsShouldBeDeleted_()
        {
            certificate.ValidateDeleteCertificate();
        }
    }
}
