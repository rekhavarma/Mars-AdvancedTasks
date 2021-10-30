﻿using AventStack.ExtentReports;
using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using static MarsQA_1.Helpers.CommonMethods;


namespace MarsQA_1.Pages
{
    public class Language
    {
        //Click on lamguages tab
        public IWebElement LangTab => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div//form//a[.='Languages']"));

        //Click on Add New button
        public IWebElement AddNew => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[2]//table//div[.='Add New']"));

        //Enter the language
        public IWebElement LangName => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

        //Click on Add
        public IWebElement AddBtn => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[2]//input[@value='Add']"));
        public IWebElement UpdateLg => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[2]//table//input[@value='Update']"));

        public void LanguageTab()
        {
            //Click on LanguageTab
            LangTab.Click();
        }

        public void AddLang()
        {
            #region Add New Language

            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileLanguage");

            for (int i = 2; i <= 4; i++)
            {
                // Driver.TurnOnWait();

                //Click on Add New button
                AddNew.Click();
                Thread.Sleep(3000);

                //Enter the language

                LangName.SendKeys(ExcelLibHelper.ReadData(i, "Language"));
                Driver.TurnOnWait();
                //Select the language level from drodown list.
                SelectElement select = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name ='level']")));
                Driver.TurnOnWait();
                select.SelectByValue(ExcelLibHelper.ReadData(i, "LanguageLevel"));
                //Generating random value to select option from dropdown list
                //Random rnd = new Random();
                //int count = rnd.Next(2, i);
                //DropDownLanguage.SelectByIndex(count);

                //Click on Add
                AddBtn.Click();
                Thread.Sleep(2000);

            }
            #endregion

        }
        //Validate Added Language
        public void ValidateAddedLang()
        {
            #region Validate the language is added sucessfully 
            try
            {
                //Start the Reports
                test = extent.CreateTest("Add Language");
                test.Log(Status.Info, "Adding language");
                String expectedValue = ExcelLibHelper.ReadData(2, "Language");

                //Get the table list
                IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));

                //Get the row count in table
                var rowCount = Tablerows.Count;
                for (var i = 1; i < rowCount; i++)
                {
                    Thread.Sleep(3000);
                    string actualValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        test.Log(Status.Pass, "Add Language Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "AddLanguage");
                        Assert.IsTrue(true);
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
            #endregion
        }

        // Update the given Language
        public void UpdateLang()
        {
            
             #region Update the given Language
             Thread.Sleep(3000);

             // Populate Login page test data collection
             ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileLanguage");
             String expectedValue = ExcelLibHelper.ReadData(2, "Language");

             //Get the table list
             IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));

             //Get the row count in table
             var rowCount = Tablerows.Count;
             for (int i = 1; i <= rowCount; i++)
             {
                 //Get the xpath of ith row Language name
                 String actualValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;

                 //check if the editLanguage Parameter matches with ith row Language name
                 if (actualValue.Equals(expectedValue))
                 {
                     //CliCk on Edit icon
                     Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();

                     //Send Language name to update
                     IWebElement editRowValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));

                     //Clear Previous text 
                     editRowValue.Clear();
                     editRowValue.SendKeys(ExcelLibHelper.ReadData(2, "UpdateLanguage"));

                     //Select Language Level to update
                     var langLevelList = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                     var selectElement = new SelectElement(langLevelList);
                     selectElement.SelectByValue(ExcelLibHelper.ReadData(2, "UpdateLanguageLevel"));

                     // Click on update button
                     Thread.Sleep(3000);
                     Driver.driver.FindElement(By.XPath("//form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + i + "]/tr[1]/td[1]/div[1]/span[1]/input[1]")).Click();

                 }
            #endregion
        }

        }


        //Validate Updated Language
        public void ValidateUpdateLang()
        {
            #region validate updated language
            try
            {
                //Start the Reports
               
                Driver.TurnOnWait();
                test = extent.CreateTest("Edit Language");
                test.Log(Status.Info, "Editing language");
                Driver.TurnOnWait();
                String expectedValue1 = ExcelLibHelper.ReadData(2, "UpdateLanguage");
                
                //Get the table list
                IList<IWebElement> UpdatedTablerows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                
                //Get the row count in table
                var UpdatedrowCount1 = UpdatedTablerows.Count;
                for (var j = 1; j < UpdatedrowCount1; j++)
                {
                    string actualValue1 = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + j + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue1 == actualValue1)
                    {
                        test.Log(Status.Pass, "Language updated Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "UpdateLanguage");
                        Assert.IsTrue(true);
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
            #endregion
        }

        //Delete a given language
        public void DeleteLang()
        {
            #region Delete given language
           
            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileLanguage");
            String expectedValue = ExcelLibHelper.ReadData(2, "DeleteLanguage");
           
            //Get the table row list
            IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
           
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row LanguageName
                String actualValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                
                //check if the DeleteLanguage parameter matches with ith Row LanguageName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();

                }
            }
            #endregion

        }
        //Validate Deleted Language
        public void ValidateDelLan()
        {
            #region Valdidate deleted laguage

            try
            {
                //Start the Reports
                test = extent.CreateTest("Remove Language");
                test.Log(Status.Info, "Deleting language");
                String expectedValue1 = ExcelLibHelper.ReadData(2, "DeleteLanguage");
                
                //Get the table list
                IList<IWebElement> Tablerows1 = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                
                //Get the row count in table
                var rowCount1 = Tablerows1.Count;
                for (var j = 1; j < rowCount1; j++)
                {
                    Thread.Sleep(3000);
                    string actualValue1 = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + j + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue1 != actualValue1)
                    {
                        Assert.IsTrue(true);
                        test.Log(Status.Pass, "Language deleted Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "DeleteLanguage");
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
            #endregion
        }






    }


}
