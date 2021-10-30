using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.Pages
{
    class Notification
    {
        #region elements
        public IWebElement NotificationButton => Driver.driver.FindElement(By.XPath("//div[contains(@class,'ui top left pointing dropdown item')]"));
        public IWebElement MarkAllAsRead => Driver.driver.FindElement(By.XPath("//div/center/a[text() = 'Mark all as read']"));
        public IWebElement SeeAll => Driver.driver.FindElement(By.XPath("//div/center/a[@href]"));
        public IWebElement LoadMore => Driver.driver.FindElement(By.XPath("//a[@class = 'ui button'][text() = 'Load More...']"));
        public IWebElement ShowLess => Driver.driver.FindElement(By.XPath("//a[@class = 'ui button'][text() = '...Show Less']"));
        public IWebElement SelectAll => Driver.driver.FindElement(By.XPath("//div[@class = 'ui icon basic button'][@data-tooltip = 'Select all']"));
        public IWebElement DeleteSelection => Driver.driver.FindElement(By.XPath("//div[@class = 'ui icon basic button'][@data-tooltip = 'Delete selection']"));
        public IWebElement notifications => Driver.driver.FindElement(By.XPath("//i[@class='icon list']"));
        public IWebElement seeAll => Driver.driver.FindElement(By.XPath("//*[contains(text(), 'See All...')]"));
        public IWebElement selectServiceReqTkBx => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='0']"));
        public IWebElement selectServiceReqTkBx2 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='1']"));
        public IWebElement selectServiceReqTkBx3 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='2']"));
        public IWebElement selectServiceReqTkBx4 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='3']"));
        public IWebElement selectServiceReqTkBx5 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='4']"));
        public IWebElement selectAll => Driver.driver.FindElement(By.XPath("//i[@class='mouse pointer icon']"));
        public IWebElement unselectAll => Driver.driver.FindElement(By.XPath("//div[@class='ui icon basic button button-icon-style']"));
        public IWebElement markSelectionAsRead => Driver.driver.FindElement(By.XPath("//i[@class='check square icon']"));
        public IWebElement popUpMessageSelectionRead => Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")); 
        #endregion

        #region locators
        public By ServiceRequest = By.XPath("//div[@class = 'extra']/div[@id = 'myDIV']");
        public By ShowLessLocator = By.XPath("//a[@class = 'ui button'][text() = '...Show Less']");
        public By NumberLocator = By.XPath("//div[@class = 'floating ui blue label']"); 
        public By NoNotificationLocator = By.XPath("//div[@class = 'ui items segment']/span/div[@class = 'item']");
        #endregion

        #region methods
        public void ClikNotificatns()
        {
            notifications.Click();
        }

        public void SeeAllNotificatns()
        {
            //Click on See All notifications
            WaitExtentions.ElementIsVisible(Driver.driver, "Xpath", "//*[contains(text(), 'See All...')]", 5);
            seeAll.Click();

        }

        public void SelServReqst()
        {
            //Select SINGLE service request with checkbox
            WaitExtentions.ElementIsVisible(Driver.driver, "Xpath", "//input[@type='checkbox' and @value='0']", 5);
            selectServiceReqTkBx.Click();
        }

        public void SeltMulSerReqsts()
        {
            //Select MULTIPLE service requests with checkbox
            WaitExtentions.ElementIsVisible(Driver.driver, "Xpath", "//input[@type='checkbox' and @value='0']", 5);
            selectServiceReqTkBx.Click();
            selectServiceReqTkBx2.Click();
            selectServiceReqTkBx3.Click();
        }

        public void SeltAllSerReqts()
        {

            Thread.Sleep(5000);
            selectAll.Click();
        }

        public void MarkSelection()
        {
            //Click on mark selection as read
            markSelectionAsRead.Click();
            WaitExtentions.ElementIsVisible(Driver.driver, "Xpath", "//div[contains(text(),'Notification updated')]", 5);
        }

        public void UnselectAllRequests()
        {
            unselectAll.Click();
        }

        public void AllSerReqtsSeletdAssertn()
        {
            WaitExtentions.ElementIsVisible(Driver.driver, "Xpath", "//div[@class='ui icon basic button button-icon-style']", 5);
            try
            {
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='0']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='1']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='2']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='3']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='4']")).Selected);

            }
            catch (Exception e)
            {

            }
        }
        public void UnseltAllAssertn()
        {
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='0']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='1']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='2']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='3']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='4']")).Selected);

        }

        public void ClikNotificationBtn()
        {
            Actions action = new Actions(Driver.driver);
            action.MoveToElement(NotificationButton).Perform();
            // NotificationButton.Click();
            Thread.Sleep(2000);

        }
        public void ClikMrkAllAsReadBtn()
        {
            WaitExtentions.WaitClickable(Driver.driver, MarkAllAsRead);
            MarkAllAsRead.Click();
        }
        public void ClikSeeAllBtn()
        {
            WaitExtentions.WaitClickable(Driver.driver, SeeAll);
            SeeAll.Click();
        }
        public void ClikLoadMoreButton()
        {
            WaitExtentions.WaitClickable(Driver.driver, LoadMore);
            LoadMore.Click();
        }
        public void ClikShowLessBtn()
        {
            WaitExtentions.WaitClickable(Driver.driver, ShowLess);
            ShowLess.Click();
        }
        public void ClikSelAllBtn()
        {
            WaitExtentions.WaitClickable(Driver.driver, SelectAll);
            SelectAll.Click();
        }
        public void ClickDelectSelectionButton()
        {
            WaitExtentions.WaitClickable(Driver.driver, DeleteSelection);
            DeleteSelection.Click();
        }
        public void TikNotifictnItem(int i)
        {
            //i: The index of the notification item in the notification list
            var itemWebElement = "//input[@type = 'checkbox'][@value = '" + i.ToString() + "']";
            Console.WriteLine("item index is " + i + ", element locator path = " + itemWebElement);
            WaitExtentions.WaitClickble(Driver.driver, By.XPath(itemWebElement), 5);
            Driver.driver.FindElement(By.XPath(itemWebElement)).Click();
        }
        #endregion

        #region assertion
        public string getServiceReqTxt()
        {
            WaitExtentions.WaitVisible(Driver.driver, ServiceRequest, 5);
            return Driver.driver.FindElement(ServiceRequest).Text;
        }
        public string getNoNotificatnText()
        {
            WaitExtentions.WaitVisible(Driver.driver, NoNotificationLocator, 5);
            return Driver.driver.FindElement(NoNotificationLocator).Text;
        }
        public bool isShowLessBtnVisible()
        {
            return WaitExtentions.WaitVisible(Driver.driver, ShowLessLocator, 5);
        }
        public bool isNumberVisible()
        {
            Thread.Sleep(3000);
            return WaitExtentions.WaitVisible(Driver.driver, NumberLocator, 2);
        }
        #endregion


    }
}
