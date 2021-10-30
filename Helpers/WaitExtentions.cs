using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MarsQA_1.Helpers
{
   public static class WaitExtentions
    {

        public static bool WaitForElementDisplayed(this IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)).Displayed);
        }

        public static IWebElement WaitForElementClickable(this IWebElement element, IWebDriver driver, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

        }
        public static void WaitClickable(IWebDriver driver, IWebElement element)
        {
            Thread.Sleep(2000);
            try
            {
                var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                Wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception error)
            {
                Assert.Fail("Time out to find element: " + error);
            }
        }

        public static void ElementIsVisible(IWebDriver driver, string locator, string locatorValue, int seconds)
        {
            try
            {
                if (locator == "XPath")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
                }
                if (locator == "CssSelector")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
                }
                if (locator == "ClassName")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));
                }

            }
            catch (Exception msg)
            {
                Assert.Fail("Test failed waiting for element to be visible", msg.Message);
            }
        }
        public static void WaitClickble(IWebDriver driver, By locator, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("The element is not clickable, time out, " + ex.Message);
            }
        }

        //explicit wait
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }
        public static bool WaitVisible(IWebDriver webDriver, By locator, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("The element is not visible, time out, " + ex.Message);
                return false;
            }
        }
        public static IWebElement FindElement(IWebDriver webDriver, By by)
        {
            try
            {
                var webElement = webDriver.FindElement(by);
                return webElement;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Did not find the element." + ex.Message);
                return null;
            }
        }



    }
}
