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
    class ProfileSkills
    {

        public IWebElement SkillTab => Driver.driver.FindElement(By.XPath("//a[normalize-space()='Skills']"));
        public IWebElement Skilladd => Driver.driver.FindElement(By.XPath("//div[@class='ui teal button']"));
        public IWebElement Skills => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        public IWebElement SkillBtn => Driver.driver.FindElement(By.XPath("//input[@value='Add']"));

        public void SkillsTab()
        {
            SkillTab.Click();
            Thread.Sleep(3000);
        }
        public void AddSkill()
        {
            #region Add New Skill
            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileSkills");
            //click on Skill
            Thread.Sleep(3000);

            for (int i = 1; i <= 3; i++)
            {
                //Click on Add New button
                Skilladd.Click();
                Thread.Sleep(2000);
                //Enter the Skill
                Skills.SendKeys(ExcelLibHelper.ReadData(i + 1, "Skill"));
                //Select the Skill level.
                SelectElement select = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name ='level']")));
                select.SelectByValue(ExcelLibHelper.ReadData(i + 1, "SkillLevel"));
                //Click on Add
                SkillBtn.Click();
            }
            #endregion
        }
        public void ValidateAddSkill()
        {
            #region Validate the Skill is added sucessfully 
            try
            {
                //Start the Reports
                test = extent.CreateTest("Add Skill");
                test.Log(Status.Info, "Adding Skill");
                String expectedValue = ExcelLibHelper.ReadData(2, "Skill");
                //Get the table list
                IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var rowCount = Tablerows.Count;
                for (var i = 1; i < rowCount; i++)
                {
                    Thread.Sleep(3000);
                    string actualValue = Driver.driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        test.Log(Status.Pass, "Skill added Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "AddSkill");
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

        // Update the given Skill
        public void UpdateSkill()
        {
            #region Update the given Skills
            Thread.Sleep(3000);
            // Populate Login page test data collection  
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileSkills");
            String expectedValue = ExcelLibHelper.ReadData(2, "Skill");
            //Get the table list
            IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
            //Get the row count in table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Skill name
                String actualValue = Driver.driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the editLanguage Parameter matches with ith row Language name
                if (actualValue.Equals(expectedValue))
                {
                    //CliCk on Edit icon
                    Driver.driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();
                    //Send Skill name to update
                    IWebElement editRowValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    //Clear Previous text 
                    editRowValue.Clear();
                    editRowValue.SendKeys(ExcelLibHelper.ReadData(i + 1, "UpdatedSkill"));
                    //Select Skill Level to update
                    var skillLevelList = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                    var selectElement = new SelectElement(skillLevelList);
                    selectElement.SelectByIndex(1);
                    // Click on update button
                    Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();
                }
            }
            #endregion

        }

        //Validating Updated Skills         
        public void ValidateUpdateSkill()
        {
            #region validate updated Skill
            try
            {
                //Start the Reports
                test = extent.CreateTest("Edit Skill");
                test.Log(Status.Info, "Editing Skill");
                String expectedValue1 = ExcelLibHelper.ReadData(2, "UpdatedSkill");
                //Get the table list
                IList<IWebElement> UpdatedTablerows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var UpdatedrowCount1 = UpdatedTablerows.Count;
                for (var j = 1; j < UpdatedrowCount1; j++)
                {
                    string actualValue1 = Driver.driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + j + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue1 == actualValue1)
                    {
                        test.Log(Status.Pass, "Skill updated Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillLanguage");
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

        //Delete a given Skill
        public void DeleteSkill()
        {
            #region Delete given Skill
            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileSkills");
            String expectedValue = ExcelLibHelper.ReadData(2, "DeleteSkill");
            //Get the table row list
            IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {

                Thread.Sleep(3000);
                String actualValue = Driver.driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the DeleteSkill parameter matches with ith Row SkillName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    Driver.driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();

                }
            }
            #endregion
        }


        //Validating Updated Skills         
        public void ValidateDelSkill()
        {
            #region Valdidate deleted Skill
            try
            {
                //Start the Reports
                test = extent.CreateTest("Delete Skill");
                test.Log(Status.Info, "Deleting Skill");
                String expectedValue1 = ExcelLibHelper.ReadData(2, "DeleteSkill");
                //Get the table list
                IList<IWebElement> Tablerows1 = Driver.driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
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
                        test.Log(Status.Pass, "Skill deleted Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "DeleteSkill");
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