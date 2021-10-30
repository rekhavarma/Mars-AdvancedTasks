using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.Pages
{
   class ProfilePage
    {

        public IWebElement ProfTab => Driver.driver.FindElement(By.LinkText("Profile"));
        //profile Available time
        public IWebElement Availtimeicon => Driver.driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/span[1]/i[1]"));
        //profile Available hours
        public IWebElement Availhouricon => Driver.driver.FindElement(By.XPath("//span[normalize-space()='Less than 30hours a week']//i[@class='right floated outline small write icon']"));
        //profile Available Target
        public IWebElement AvailTargicon => Driver.driver.FindElement(By.XPath("//span[normalize-space()='Less than $500 per month']//i[@class='right floated outline small write icon']"));
        
        //Profile Description 
        public IWebElement AvailDesicon => Driver.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
        public IWebElement Descriptiontxt => Driver.driver.FindElement(By.XPath("//textarea[@placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']"));
        public IWebElement BtnDesSave => Driver.driver.FindElement(By.XPath("//button[@type='button']"));

        //Profile Change Password
        public IWebElement welcomeTab => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
        public IWebElement ChangPassDropdow => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/div[1]/div[2]/div/span/div[@class='menu transition visible']/a[2]"));
        public IWebElement CurrPass => Driver.driver.FindElement(By.XPath("//body[@class='dimmable dimmed']/div[4]//form//input[@name='oldPassword']"));
        public IWebElement NewPass => Driver.driver.FindElement(By.XPath("//body[@class='dimmable dimmed']/div[4]//form//input[@name='newPassword']"));
        public IWebElement ConfirmPass => Driver.driver.FindElement(By.XPath("//body[@class='dimmable dimmed']/div[4]//form//input[@name='confirmPassword']"));
        public IWebElement SaveButton => Driver.driver.FindElement(By.XPath("//body[@class='dimmable dimmed']/div[4]//form//button[@role='button']"));
        
        //Profile Chat
        public IWebElement Chaticon => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/div[1]//a[@href='/Home/Message']"));
        public IWebElement ChatSearch => Driver.driver.FindElement(By.XPath("/html//div[@id='chatRoomContainer']/div[@class='chatRoom']//input[@class='prompt']"));
        public IWebElement Chatname => Driver.driver.FindElement(By.XPath("/html//div[@id='chatList']/div[1]/div[@class='content']/div[@class='header']"));
        public IWebElement Chattextbox => Driver.driver.FindElement(By.XPath("/html//input[@id='chatTextBox']"));
        public IWebElement chatsendtab => Driver.driver.FindElement(By.XPath("/html//button[@id='btnSend']"));
       

        public void ClickProTab()

        {

         ProfTab.Click();
        }
        #region Availability
        public void AvailabiTimeLnk()
        {
            Thread.Sleep(3000);
            Availtimeicon.Click();
        }
        public  void AvailableType()
        {
            var Worktype = Driver.driver.FindElement(By.Name("availabiltyType"));
            var selectElementh = new SelectElement(Worktype);
            selectElementh.SelectByValue("0");

            Thread.Sleep(5000);
        }
        #endregion

        #region Availablehour
        public  void AvailabiHourLnk()
        {
            Availhouricon.Click();
        }
        public  void AvailabilyHour()
        {
            Thread.Sleep(5000);
            var Workhour = Driver.driver.FindElement(By.Name("availabiltyHour"));
            var selectElement = new SelectElement(Workhour);
            selectElement.SelectByValue("0");
            Thread.Sleep(5000);
        }
        #endregion
        #region EarnTarget
        public  void AvailabiTargetLnk()
        {
            Thread.Sleep(5000);
            AvailTargicon.Click();
        }
        public  void AvailabilityTargt()
        {
            var Target = Driver.driver.FindElement(By.Name("availabiltyTarget"));
            var selectElementt = new SelectElement(Target);
            selectElementt.SelectByValue("0");
            Thread.Sleep(5000);

        }
        #endregion
        #region Add Description
        public  void AvailabiDesLnk()
        { 

            AvailDesicon.Click();

        }
        public void AvailableDescrip()
        {
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            Thread.Sleep(1000);
            Descriptiontxt.SendKeys(Keys.Control + "a");
            Descriptiontxt.SendKeys(Keys.Delete);
            Descriptiontxt.SendKeys(ExcelLibHelper.ReadData(2, "Description"));
        }
        public  void AvailableDescripsave()
        {
            BtnDesSave.Click();
            Thread.Sleep(5000);
            Driver.driver.SwitchTo().Window(Driver.driver.WindowHandles.Last());
            // verify Description is save successfully 
            Assert.AreEqual(Driver.driver.FindElement(By.XPath("/html/body/div[1]/div")).Text, "Description has been saved successfully");
            Driver.driver.SwitchTo().DefaultContent();

        }
        #endregion

        #region Change Password
        public void ChangePasswordtab()
        {
          
            Thread.Sleep(2000);
            // Navigate to change password page
            welcomeTab.Click();
            Thread.Sleep(2000);
            ChangPassDropdow.Click();
        }
        public void ChangePassword()
        {
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");
            Thread.Sleep(2000);
            CurrPass.SendKeys(ExcelLibHelper.ReadData(2, "CurrentPassword"));
            NewPass.SendKeys(ExcelLibHelper.ReadData(2, "NewPassword"));
            Thread.Sleep(2000);
            ConfirmPass.SendKeys(ExcelLibHelper.ReadData(2, "ConfirmPassword"));
        }
        public void SaveBtn()
        {
            // click on save button
            SaveButton.Click();
            Thread.Sleep(5000);

        }

        #endregion


        #region Chat in profile

        public void Chat()
        {
            Chaticon.WaitForElementClickable(Driver.driver, 60);
            Chaticon.Click();
        }
        public void Chatsearch()
        {
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");
            Thread.Sleep(2000);
            ChatSearch.Click();
            ChatSearch.SendKeys(ExcelLibHelper.ReadData(2, "ChatSearch"));
        }

        public void ChatsearchVisible()
        {
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");
            Thread.Sleep(2000);
            String Searchtxt = Driver.driver.FindElement(By.XPath("//div[normalize-space()='rekha']")).Text; ;
            Assert.AreEqual(Searchtxt, ExcelLibHelper.ReadData(2, "ChatSearch"));

        }
        public void ChatMessage()
        {
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");
            Thread.Sleep(2000);
            Chattextbox.Click();
            Chattextbox.SendKeys(ExcelLibHelper.ReadData(2, "ChatTextBox"));

        }
        public void ChatSendbtn()
        {
            chatsendtab.Click();

        }

        #endregion

        #region Validate Chat


        #endregion
    }
}
