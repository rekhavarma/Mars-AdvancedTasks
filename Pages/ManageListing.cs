using AventStack.ExtentReports;
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
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.Pages
{
    class ManageListing : ShareSkills
    {
        //Manage listing link
        private static IWebElement ManageListingsLink => Driver.driver.FindElement(By.XPath("//a[normalize-space()='Manage Listings']"));
        //View icon
        private static IWebElement View => Driver.driver.FindElement(By.XPath("/html//div[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]/i[@class='eye icon']"));
        //Delete icon
        private static IWebElement Delete => Driver.driver.FindElement(By.XPath("//i[@class='remove icon']"));
        //Edit button/Icon
        private static IWebElement Edit => Driver.driver.FindElement(By.XPath("/html//div[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i"));
        //Click on Yes or No
        private static IWebElement clickActiveButton => Driver.driver.FindElement(By.XPath("//tbody/tr[1]/td[7]/div[1]/input[1]"));
        //Yes button
        private static IWebElement ClickYes => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        //No button
        private static IWebElement clickNoButton => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]"));
        //Category type button
        private static IWebElement categoryType => Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));
        //title of the page
        private static IWebElement titleText => Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
        //Select Description for the top row
        private static IWebElement descriptionText => Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
        //Delete confirmation  Message
        private static IWebElement messageDisplay => Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/h3"));
        //Enter the Title in textbox
        private static IWebElement title => Driver.driver.FindElement(By.Name("title"));
        //Enter the Description in textbox
        private static IWebElement DescriptionText => Driver.driver.FindElement(By.Name("description"));
        //Select service type
        private static IWebElement Header => Driver.driver.FindElement(By.XPath("//*[@id='service - detail - section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]"));
       
        //Find Service Detail Page
        private static IWebElement ServiceDetailPage => Driver.driver.FindElement(By.XPath("//*[@id='service-detail-section']"));

        public void Managelisting()
        {
            // navigate to ManageListings page
            ManageListingsLink.WaitForElementClickable(Driver.driver, 60);
            ManageListingsLink.Click();
            Driver.wait(2);
        }

        public void ValidateManageListingPage()
        {
            #region Check if user on ManageListing Page
            Driver.wait(9);
            Thread.Sleep(3000);
            string actualPageTitle = Driver.driver.Title;
            string expectedPageTitle = "ListingManagement";

            try
            {

                Thread.Sleep(3000);
                test = extent.CreateTest("User should be on ManageListing Page");
                if (expectedPageTitle == actualPageTitle)
                {
                    test.Log(Status.Pass, "Test Passed, User is on ManageListing Page");
                    test.Log(Status.Info, "Validating the user is on ManageListing Page");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "ManageListingPage");
                    Assert.Pass("Test Passed, User is on ManageListing Page");
                }
                else
                {
                    test.Log(Status.Fail, "Test Failed");
                    Assert.Fail("Test Failed, User is not on ManageListing Page");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        }


        public void EditshareSkill()
        {
            // navigate to ManageListings page
            // ManageListingsLink.WaitForElementClickable(driver, 60);
            ManageListingsLink.Click();
            Driver.wait(2);
            Edit.WaitForElementClickable(Driver.driver, 60);
            Edit.Click();
            Driver.wait(2);
            //Populate the excel data
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ManageListing");

            #region Enter Title
            //Enter data in Title text box
            Driver.wait(3);
            Title.Clear();
            Driver.wait(2);
            Title.SendKeys(ExcelLibHelper.ReadData(2, "Title"));
            #endregion

            #region Enter Description
            Driver.wait(2);
            //Enter data in Description text box
            Description.Clear();
            Driver.wait(2);
            Description.SendKeys(ExcelLibHelper.ReadData(2, "Description"));
            #endregion

            #region Select Category 
            Driver.wait(2);
            //click on category dropdown menu
            CategoryDropDown.Click();
            //Select Category from dropdown menu
            var selectElement = new SelectElement(CategoryDropDown);
            selectElement.SelectByText((ExcelLibHelper.ReadData(2, "Category")));
            Driver.wait(2);
            //click on subcategory dropdown menu
            SubCategoryDropDown.Click();
            //Select subCategory from dropdown menu
            var Selectelement = new SelectElement(SubCategoryDropDown);
            Selectelement.SelectByText((ExcelLibHelper.ReadData(2, "SubCategory")));
            #endregion

            #region Select Available days
            //select start date
            Driver.wait(2);
            StartDateDropDown.SendKeys(ExcelLibHelper.ReadData(2, "Startdate"));
            //select end date
            Driver.wait(2);
            EndDateDropDown.SendKeys(ExcelLibHelper.ReadData(2, "Enddate"));

            //select available days and start time and end time

            IList<IWebElement> Starttime = Driver.driver.FindElements(By.Name("StartTime"));

            IList<IWebElement> Endtime = Driver.driver.FindElements(By.Name("EndTime"));

            IList<IWebElement> Checkbox = Driver.driver.FindElements(By.XPath("(//input[@name='Available'])"));

            if (Checkbox.Count != 0)
            {
                //selecting checkboxs from monday to friday

                for (int i = 1; i <= Checkbox.Count - 2; i++)
                {
                    //verify whether checkbox is not selected

                    if (!Checkbox.ElementAt(i).Selected)
                    {
                        Checkbox.ElementAt(i).Click();
                    }
                    Console.WriteLine(Driver.driver);

                    //validating the count
                    Driver.wait(2);

                    Starttime.ElementAt(i).SendKeys(ExcelLibHelper.ReadData(i + 1, "Starttime"));

                    Thread.Sleep(2000);

                    Endtime.ElementAt(i).SendKeys(ExcelLibHelper.ReadData(i + 1, "Endtime"));

                    Driver.wait(2);
                }
            }

            #endregion

            #region Enter tags

            //click on tags
            Driver.wait(2);
            Tags.Click();
            //Enter a tag
            Driver.wait(2);
            Tags.SendKeys((ExcelLibHelper.ReadData(2, "Tags")));
            Driver.wait(2);
            Tags.SendKeys(Keys.Enter);
            Driver.wait(2);
            #endregion

            #region select skill trade
            //select skilltrade
            Driver.wait(4);
            String SkillTradeType = ((ExcelLibHelper.ReadData(2, "SkillTradeType")));
            if (SkillTradeType.Equals("Skill-exchange"))
            {
                SkillExchangeType.Click();
            }
            else if (SkillTradeType.Equals("Credit"))
            {
                CreditsType.Click();
                CreditAmount.SendKeys(ExcelLibHelper.ReadData(2, "CreditsAmount"));

            }
            //Add Credit Tag
            CreditsType.Click();
            CreditAmount.SendKeys(ExcelLibHelper.ReadData(2, "CreditsAmount"));
            CreditAmount.SendKeys(Keys.Enter);

            #endregion
        }
        public void savebutton() 
        { 
            #region click on save button
            Save.WaitForElementClickable(Driver.driver, 60);
            Save.Click();
            Driver.wait(1);
            #endregion
       
            #region  Check if skill Updated successfully
            Driver.wait(9);
            Thread.Sleep(3000);
            string actualPageTitle = Driver.driver.Title;
            string expectedPageTitle = "ListingManagement";

            try
            {

                Thread.Sleep(3000);
                test = extent.CreateTest("Edit Service Listing");
                if (expectedPageTitle == actualPageTitle)
                {
                    test.Log(Status.Pass, "Test Passed, Service listing updated Successfully");
                    test.Log(Status.Info, "Validating the edit Share Skill");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillsUpdatedSuccessfully");
                    Assert.Pass("Test Passed, Skills Updated");
                }
                else
                {
                    test.Log(Status.Fail, "Test Failed");
                    Assert.Fail("Test Failed, Skill not Updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        }

        
        public void ViewShareSkill()
        {
            // navigate to ManageListings page
            ManageListingsLink.WaitForElementClickable(Driver.driver, 60);
            ManageListingsLink.Click();

            //Identify and Click on View Button
            View.WaitForElementClickable(Driver.driver, 60);
            View.Click();
            Driver.wait(3);

            #region  Check if skill created successfully
            Driver.wait(2);

            string actualPageTitle = Driver.driver.Title;
            string expectedPageTitle = "Service Detail";
            Assert.AreEqual(actualPageTitle, "Service Detail");

            try
            {

                Driver.wait(2);
                test = extent.CreateTest("View Service Listing");
                if (expectedPageTitle == actualPageTitle)
                {
                    test.Log(Status.Pass, "Test Passed, Service listing Visible Successfully");
                    test.Log(Status.Info, "Validating the View Share Skill");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillsViewedSuccessfully");
                    Assert.Pass("Test Passed, Skills Visible");
                }
                else
                {
                    test.Log(Status.Fail, "Test Failed");
                    Assert.Fail("Test Failed, Skill not Visible");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

        }


        public void DeleteShareSkill()
        {
            // navigate to ManageListings page
            ManageListingsLink.WaitForElementClickable(Driver.driver, 60);
            ManageListingsLink.Click();

            //Identify and click on delete button
            Delete.WaitForElementClickable(Driver.driver, 60);
            Delete.Click();
            Driver.wait(2);
        }

        public void Alertmessage() 
        { 

            // Switch to Popup button
            ClickYes.WaitForElementClickable(Driver.driver, 60);
            ClickYes.Click();
            Driver.wait(2);
        }

        public void ValidateDeleteListing()

        {
            #region  Check if skill created successfully
            Thread.Sleep(3000);
            string actualPageTitle = Driver.driver.Title;
            string expectedPageTitle = "ListingManagement";

            try
            {
                Thread.Sleep(1000);
                test = extent.CreateTest("Delete Service Listing");
                if (expectedPageTitle == actualPageTitle)
                {
                    test.Log(Status.Pass, "Test Passed, Service listing Deleted Successfully");
                    test.Log(Status.Info, "Validating the Delete Share Skill");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillsDeletedSuccessfully");
                    Assert.Pass("Test Passed, Skills Deleted");
                }
                else
                {
                    test.Log(Status.Fail, "Test Failed");
                    Assert.Fail("Test Failed, Skill not Deleted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

        }

    }
}
