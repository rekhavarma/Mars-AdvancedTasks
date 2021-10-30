using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.Pages
{
    class RecievedRequest
    {
        public RecievedRequest()
        {
        }

        public IWebElement ManRequestDrpdwn => Driver.driver.FindElement(By.XPath("//div[@class='ui dropdown link item']"));
        public IWebElement Rerdrpdwn => Driver.driver.FindElement(By.LinkText("Received Requests"));
        public IWebElement AcceptButton => Driver.driver.FindElement(By.XPath("//button[normalize-space()='Accept']"));
        public IWebElement DeclineButton => Driver.driver.FindElement(By.XPath("//button[normalize-space()='Decline']"));
        public IWebElement CompleteButton => Driver.driver.FindElement(By.XPath("//button[text()='Complete']"));
        //   public IWebElement DecStat => Driver.FindElement(By.XPath("//div[@id='received-request-section']/div[2]/div/table/tbody/tr[2]/td[5]"));

        //Click on Manage Request Tab
        public void ManageRequest()
        {
            ManRequestDrpdwn.Click();
            Thread.Sleep(2000);
        }

        //Select on Receive Request Menu
        public void RecRequest()
        {
            Rerdrpdwn.Click();
            Thread.Sleep(2000);
        }

        // Click On Decline Button
        public void RequestAccept()
        {
            AcceptButton.Click();
            WaitExtentions.WaitForElement(Driver.driver, By.XPath("//div[contains(@class,'ns-box ns-growl ns-effect-jelly ns-type-success ns-show')]"), 10);
        }

        //Validating Accept Status
        public void AcceptStatus()
        {
            string AccStat = Driver.driver.FindElement(By.XPath("//div[@id='received-request-section']/div[2]/div/table/tbody/tr[1]/td[5]")).Text;
            Assert.AreEqual(AccStat, "Accepted");
        }

        // Click On Decline Button
        public void RequestDecline()
        {
            DeclineButton.Click();
            WaitExtentions.WaitForElement(Driver.driver, By.XPath("//div[contains(@class,'ns-box ns-growl ns-effect-jelly ns-type-success ns-show')]"), 10);
        }

        //Validating Decline Status
        public void DeclineStatus()
        {
            string DecStat = Driver.driver.FindElement(By.XPath("//div[@id='received-request-section']/div[2]/div/table/tbody/tr[2]/td[5]")).Text;
            Assert.AreEqual(DecStat, "Declined");
        }
        //Validating Complete button is Displayed
        public void RequestCompleted()
        {
            bool isPresent = CompleteButton.Displayed;
        }
    }
}
