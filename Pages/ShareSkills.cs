using AutoIt;
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
    class ShareSkills
    {
        //ShareSkill Button
        public static IWebElement ShareSkillTab => Driver.driver.FindElement(By.LinkText("Share Skill"));

        //Title in textbox
        public static IWebElement Title  => Driver.driver.FindElement(By.Name("title"));

        //Description in textbox
        public static IWebElement Description => Driver.driver.FindElement(By.Name("description"));

        //Category Dropdown
        public static IWebElement CategoryDropDown => Driver.driver.FindElement(By.Name("categoryId"));

        //SubCategoryDropDown 
        public static IWebElement SubCategoryDropDown => Driver.driver.FindElement(By.Name("subcategoryId"));

        //Tag names in textbox
        public static IWebElement Tags => Driver.driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));

        //Select the Service type
        public static IWebElement ServiceTypeOptions => Driver.driver.FindElement(By.XPath("//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']"));

        //Select Hourly service type
        public static IWebElement HourlyServiceType => Driver.driver.FindElement(By.Name("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));

        //Select OneOff ServiceType type
        public static IWebElement OneOffServiceType => Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[5]/div[2]/div[1]/div[2]/div[1]/input[1]"));

        //Select the Location Type
        public static IWebElement LocationTypeOption => Driver.driver.FindElement(By.XPath("//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Select On-Site Location Type
        private static IWebElement OnSiteLocationType => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));

        //Select Online Location Type
        public static IWebElement OnlineLocationType => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));

        //Start Date dropdown
        public static IWebElement StartDateDropDown => Driver.driver.FindElement(By.Name("startDate"));

        //EndDateDropDown
        public static IWebElement EndDateDropDown => Driver.driver.FindElement(By.Name("endDate"));

        //Skill Trade option
        public static IWebElement SkillTradeOption => Driver.driver.FindElement(By.XPath("//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Skill Exchange
        public static IWebElement SkillExchange => Driver.driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));

        //Slelect the Skill Exchange Type
        public static IWebElement SkillExchangeType => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));

        //Credit option
        public static IWebElement Credit => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));

        //Enter the amount for Credit  
        public static IWebElement CreditAmount => Driver.driver.FindElement(By.XPath("/html//div[@id='service-listing-section']//form/div[8]/div[4]/div/div/input[@name='charge']")); 
        //Select the Credit Type
        public static IWebElement CreditsType => Driver.driver.FindElement(By.XPath("//html//div[@id='service-listing-section']/div[2]/div[@class='listing']/form/div[8]/div[2]/div/div[2]/div/input[@name='skillTrades']"));

        //Enter Skill Exchange Tag
        public static IWebElement SkillExchangeTag => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));

        // Active/Hidden option
        public static IWebElement ActiveOption => Driver.driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Select Active Button
        public static IWebElement ActiveButton => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));

        //Select Hidden Button
        public static IWebElement HiddenButton => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));

        //File upload
        public static IWebElement FileUpload => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
        //Save button
        public static IWebElement Save => Driver.driver.FindElement(By.XPath("//input[@value='Save']"));

        public void ShareSkillButton()
        {
            //click on the shareskill page
            ShareSkillTab.WaitForElementClickable(Driver.driver, 60);
            ShareSkillTab.Click();
        }

        public void AddShareSkill()
        {
            //Populate the excel data
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ShareSkill");

            #region Enter Title
            Driver.wait(3);
            //Enter data in Title text box
            Title.SendKeys(ExcelLibHelper.ReadData(2, "Title"));
            #endregion

            #region Enter Description
            Driver.wait(2);
            //Enter data in Description text box
            Description.SendKeys(ExcelLibHelper.ReadData(2, "Description"));
            #endregion

            #region Select Category 
            Driver.wait(2);
            //click on category dropdown menu
            CategoryDropDown.Click();
            //Select Category from dropdown menu
            var selectElement = new SelectElement(CategoryDropDown);
            selectElement.SelectByText((ExcelLibHelper.ReadData(2, "Category")));
            ShareSkillTab.WaitForElementClickable(Driver.driver, 60);
            //click on subcategory dropdown menu
            SubCategoryDropDown.Click();
            //Select subCategory from dropdown menu
            var Selectelement = new SelectElement(SubCategoryDropDown);
            Selectelement.SelectByText((ExcelLibHelper.ReadData(2, "SubCategory")));
            #endregion

            #region Enter tags
            Driver.wait(2);
            //click on tags
            Tags.Click();
            //Enter a tag
            Tags.SendKeys((ExcelLibHelper.ReadData(2, "Tags")));
            Tags.SendKeys(Keys.Enter);
            Driver.wait(2);
            #endregion

            #region select service type
            Driver.wait(2);
            //Select ServiceType 
            String ServiceType = ((ExcelLibHelper.ReadData(2, "ServiceType")));
            if (ServiceType.Equals("Hourly basis service"))
            {
                HourlyServiceType.Click();
            }
            else if (ServiceType.Equals("One-off service"))
            {
                OneOffServiceType.Click();
            }
            #endregion

            #region select Location Type
            Driver.wait(2);
            //Select Location Type
            String LocationType = ((ExcelLibHelper.ReadData(2, "LocationType")));
            if (LocationType.Equals("On-site"))
            {
                OnSiteLocationType.Click();
            }
            else if (LocationType.Equals("Online"))
            {
                OnlineLocationType.Click();
            }
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
                    //verify whether checkbox is not selecte

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

            #region select skill trade

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
            //Add Skill Exchange Tag
            SkillExchangeTag.SendKeys(ExcelLibHelper.ReadData(2, "SkillExchangeTab"));
            SkillExchangeTag.SendKeys(Keys.Enter);



            #endregion

            #region Upload Work Sample

            //Upload file
            Driver.wait(3);
            FileUpload.Click();
            Thread.Sleep(2000);
            //Activate Browser Window
            AutoItX.WinWaitActive("Open");
            Thread.Sleep(2000);
            //sets input focus to a given control on open window
            AutoItX.ControlFocus("Open", "", "Edit1");
            //sets text of a control
            AutoItX.ControlSetText("Open", "", "Edit1", @"C:\Users\Rekha\Desktop\MyGitHub\Standard_Task2-main\StandardTask2\Test.txt"); 
            Driver.wait(4); 
            AutoItX.ControlClick("Open", "", "Button1");
            Driver.wait(4);

            #endregion

            #region select Active
            //Select Status
            Driver.wait(2);
            String ActiveType = (ExcelLibHelper.ReadData(2, "ActiveType"));
            if (ActiveType.Equals("Active"))
            {
                ActiveButton.Click();
            }
            else if (ActiveType.Equals("Hidden"))
            {
                HiddenButton.Click();
            }
        }
            #endregion
        public void SaveButton()
        {
            #region save Shareskill
            Save.WaitForElementClickable(Driver.driver, 60);
            Save.Click();
            Driver.wait(2);
            #endregion
        }
        public void ValidateCreateListing()
        {
            #region  Check if skill created successfully
            Thread.Sleep(3000);
            string actualPageTitle = Driver.driver.Title;
            string expectedPageTitle = "ListingManagement";

            try
            {
                //Start the Reports

                Thread.Sleep(1000);
                test = extent.CreateTest("Add a Service Listing");
                if (expectedPageTitle == actualPageTitle)
                {
                    test.Log(Status.Pass, "Test Passed, Service listing added Successfully");
                    test.Log(Status.Info, "Validating the Create Share Skill");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillsAddedSuccessfully");
                    Assert.Pass("Test Passed, Skills saved");
                }
                else
                {
                    test.Log(Status.Fail, "Test Failed");
                    Assert.Fail("Test Failed, Skill not saved");
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

