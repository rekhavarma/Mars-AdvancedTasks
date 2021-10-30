using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_1.Pages
{
    class SentRequest
    {

        public SentRequest()
        {
        }

        public IWebElement SentDrpdwn => Driver.driver.FindElement(By.LinkText("Sent Requests"));
        public IWebElement ReqWithdraw => Driver.driver.FindElement(By.XPath("//button[normalize-space()='Withdraw']"));
        public IWebElement WithdrawStatus => Driver.driver.FindElement(By.XPath("//td[normalize-space()='Withdrawn']"));
        public IWebElement CompletBtn => Driver.driver.FindElement(By.XPath("//button[normalize-space()='Completed']"));
        public IWebElement ReviewButn => Driver.driver.FindElement(By.XPath("(//button[@type='button'])[3]"));
        public IWebElement SellerComm => Driver.driver.FindElement(By.XPath("//div[@id='communicationRating']/i[3]"));
        public IWebElement ServDesc => Driver.driver.FindElement(By.XPath("//div[@id='serviceRating']/i[3]"));
        public IWebElement Recommend => Driver.driver.FindElement(By.XPath("//div[@id='recommendRating']/i[4]"));
        public IWebElement RSavBtn => Driver.driver.FindElement(By.XPath("//div[2]/div/div[4]/div"));
        public IWebElement RevieTxt => Driver.driver.FindElement(By.XPath("//textarea[@id='reviewCommentInput']"));



        //Sent Request Menu Dropdown
        public void SenRequest()
        {
            SentDrpdwn.Click();
        }

        //Validating Pending Status
        public void PendStatus()
        {
            var PStatus = Driver.driver.FindElement(By.XPath("//td[normalize-space()='Pending']"));
            Assert.AreEqual(PStatus, "Pending");
        }

        //Click on WithdrawRequest Button
        public void WithdrawSentRequest()
        {
            ReqWithdraw.Click();
            WaitExtentions.WaitForElement(Driver.driver, By.XPath("//div[contains(@class,'ns-box ns-growl ns-effect-jelly ns-type-success ns-show')]"), 10);
        }

        //Validating Withdraw Status
        public void WithdrStatus()
        {
            string WdStatus = Driver.driver.FindElement(By.XPath("//td[normalize-space()='Withdrawn']")).Text;
            Assert.AreEqual(WdStatus, "Withdrawn");
        }

        //Validating Decline Status  
        public void DeclinStatus()
        {
            string DeclStatus = Driver.driver.FindElement(By.XPath("//td[normalize-space()='Declined']")).Text;
            Assert.AreEqual(DeclStatus, "Declined");
        }

        //Validating Pending Status
        public void Accepted()
        {
            string AcctStatus = Driver.driver.FindElement(By.XPath("//td[normalize-space()='Accepted']")).Text;
            Assert.AreEqual(AcctStatus, "Accepted");
        }

        //Validating Complete button Available 
        public void Cmpletebtn()
        {
            var Cmpltebtnvis = Driver.driver.FindElement(By.XPath("//button[normalize-space()='Completed']")).Text;
            if (Cmpltebtnvis == "Completed")
            {
                Console.WriteLine("Complete Button Visible");
            }
        }
        //Click on Complete Button
        public void Completed()
        {
            CompletBtn.Click();
        }

        //Validating Complete Status 
        public void CompleteStatus()
        {
            string ComplteStatus = Driver.driver.FindElement(By.XPath("///tbody/tr[4]/td[5]")).Text;
            Assert.AreEqual(ComplteStatus, "Completed");
        }

        //Click on Review Button
        public void ReviewBtn()
        {
            ReviewButn.Click();
        }
        // Adding Review Comments and Ratings
        public void Review()
        {
            SellerComm.Click();
            ServDesc.Click();
            Recommend.Click();
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");
            RevieTxt.SendKeys(ExcelLibHelper.ReadData(2, "Review"));
            RSavBtn.Click();
        }

    }
}
