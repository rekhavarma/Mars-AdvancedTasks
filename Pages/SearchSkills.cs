using AventStack.ExtentReports;
using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.Pages
{
    class SearchSkills
    {
        //profile tab
        public IWebElement ProfTab => Driver.driver.FindElement(By.LinkText("Profile"));

        //Click on SearchTextBox
        public IWebElement Searchtextbox => Driver.driver.FindElement(By.XPath("//div[@class='ui secondary menu']//input[@placeholder='Search skills']"));

        //Click on refine search skills
        public IWebElement RefineSreachskills => Driver.driver.FindElement(By.XPath("/html//div[@id='service-search-section']/div[2]//section[@class='search-results']/div/div[1]/div[2]/input[@type='text']"));

        //click on refine search user textbox
        public IWebElement RefineSearchUser => Driver.driver.FindElement(By.XPath("/html//div[@id='service-search-section']/div[2]//section[@class='search-results']/div/div[1]/div[3]/div[1]/div//input"));


        public void ProfileTab()
        {
            ProfTab.Click();
        }
        public void Searchskills()
        {
            #region
            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");
            //Click on Searchskills textbox
            Thread.Sleep(3000);
            Searchtextbox.WaitForElementClickable(Driver.driver, 60);
            Searchtextbox.Click();
            Searchtextbox.WaitForElementClickable(Driver.driver, 60);
            Searchtextbox.SendKeys(ExcelLibHelper.ReadData(2, "Searchskills"));
            Searchtextbox.WaitForElementClickable(Driver.driver, 60);
            Searchtextbox.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            //Validate Search Skills
            Driver.wait(9);
            Thread.Sleep(3000);
            string actualPageTitle = Driver.driver.Title;
            string expectedPageTitle = "Search";

            try
            {

                Thread.Sleep(3000);
                test = extent.CreateTest("SearchSkills");
                if (expectedPageTitle == actualPageTitle)
                {
                    test.Log(Status.Pass, "Test Passed, SearchSkills Page Visible");
                    test.Log(Status.Info, "Validating the Searchskills Page");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SearchskillsPageVisible");
                    Assert.Pass("Test Passed, SearchSkills Page Visible");
                }
                else
                {
                    test.Log(Status.Fail, "Test Failed");
                    Assert.Fail("Test Failed, SearchSkills Page doesn't Exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Thread.Sleep(5000);
            #endregion
        }
        public void RefineSearchSkills()
           {
            #region Search Refine Skills
            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");
            //Click on Searchskills textbox
            Thread.Sleep(3000);
            Searchtextbox.WaitForElementClickable(Driver.driver, 60);
            Searchtextbox.Click();
            Searchtextbox.WaitForElementClickable(Driver.driver, 60);
            Searchtextbox.SendKeys(ExcelLibHelper.ReadData(2, "Searchskills"));
            Searchtextbox.WaitForElementClickable(Driver.driver, 60);
            Searchtextbox.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            //Click on Refine Search Skills
            RefineSreachskills.WaitForElementClickable(Driver.driver, 60);
            RefineSreachskills.Click();
            Thread.Sleep(2000);
            RefineSreachskills.WaitForElementClickable(Driver.driver, 60);
            RefineSreachskills.SendKeys(ExcelLibHelper.ReadData(2, "Refineskills"));
            Thread.Sleep(2000);
            Searchtextbox.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            }
        public void RefinesearchUser()
        {
            //Click on Refine User
            RefineSearchUser.Click();
            Thread.Sleep(2000);
            RefineSearchUser.SendKeys(ExcelLibHelper.ReadData(2, "RefineSearchUser"));
            Thread.Sleep(2000);
            RefineSearchUser.SendKeys(Keys.ArrowDown + Keys.Enter);
            Thread.Sleep(6000);

        }
            public void RefineSearchVisible()
        { 
            //Validate RefineSearchSkills

            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");
            Thread.Sleep(4000);
            String ActualUser = Driver.driver.FindElement(By.LinkText("rekha")).Text;
            String ActualSkill = Driver.driver.FindElement(By.LinkText("Automating")).Text;
            Thread.Sleep(3000);
            String ExpectedUser = ExcelLibHelper.ReadData(2, "RefineSearchUser");
            String ExpectedSkill = ExcelLibHelper.ReadData(2, "Searchskills");
            Thread.Sleep(5000);

            try
            {
                Thread.Sleep(3000);
                test = extent.CreateTest("SearchSkills");

                if (ActualUser == ExpectedUser && ActualSkill == ExpectedSkill)
                {
                    Thread.Sleep(3000);
                    test.Log(Status.Info, "Validating the SearchSkills");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SearchSkills");
                    test.Log(Status.Pass, "Test Passed, SearchSkills Visible");
                    Assert.Pass("Test Passed, SearchSkills Visible");
                }
                else
                {
                    Thread.Sleep(3000);
                    test.Log(Status.Fail, "Test Failed, SearchSkills doesn't Exists ");
                    Assert.Fail("Test Fail, SearchSkills doesn't Exists");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
            Thread.Sleep(5000);
        } 

        public void RefineFilterSearchSkills()
        {
            #region Filter Search Skills
            // Populate Profile page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");
            // Search skills using filter
            string value1 = ExcelLibHelper.ReadData(2, "FilterButtons");
            string value2 = ExcelLibHelper.ReadData(3, "FilterButtons");
            string value3 = ExcelLibHelper.ReadData(4, "FilterButtons");
            // Click on button
            string Button = Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]")).Text;


            Thread.Sleep(3000);

            for (int i = 1; i <= 3; i++)
            {
                // Click on ith button
                string actualvalue = Driver.driver.FindElement(By.XPath("//div/section/div/div[1]/div[5]/button[" + i + "]")).Text;
                if (actualvalue == value1)
                {
                    Thread.Sleep(3000);
                    Driver.driver.FindElement(By.XPath("//button[normalize-space()='Online']")).Click();
                    Console.WriteLine("Test Passed for Online Filter");
                    Thread.Sleep(2000);
                }
                else if (actualvalue == value2)
                {
                    Thread.Sleep(3000);
                    Driver.driver.FindElement(By.XPath("//button[normalize-space()='Onsite']")).Click();
                    Console.WriteLine("Test Passed for Onsite Filter");
                    Thread.Sleep(2000);
                }
                else if (actualvalue == value3)
                {
                    Thread.Sleep(3000);
                    Driver.driver.FindElement(By.XPath("//button[normalize-space()='ShowAll']")).Click();
                    Console.WriteLine("Test Passed for ShowAll Filter");
                    Thread.Sleep(2000);
                }
            }

            #endregion
        }


    }
}
