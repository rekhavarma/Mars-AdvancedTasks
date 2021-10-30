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
    class Education
    {
        //Click on Education tab
        public IWebElement EducationTab => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div//form//a[.='Education']"));

        //Click on Add New button to Education
        public IWebElement AddNeweducation => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[4]//table//div"));

        //Enter university in the text box
        public IWebElement EnterUniversity => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//input[@name='instituteName']"));

        //Choose the country
        public IWebElement ChooseCountry => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//select[@name='country']"));

        //Choose the skill level option
        public IWebElement ChooseCountryOpt => Driver.driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[2]/select/option[6]"));

        //Click on Title dropdown
        public IWebElement ChooseTitle => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//select[@name='title']"));

        //Choose title
        public IWebElement ChooseTitleOpt => Driver.driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[1]/select/option[5]"));

        //Degree
        public IWebElement Degree => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//input[@name='degree']"));

        //Year of graduation
        public IWebElement DegreeYear => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//select[@name='yearOfGraduation']"));

        //Choose Year
        public IWebElement DegreeYearOpt => Driver.driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[3]/select/option[4]"));

        //Click on Add
        public IWebElement AddEdu => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//input[@value='Add']"));

        public void EduTab()
        {
            EducationTab.WaitForElementClickable(Driver.driver, 60);
            EducationTab.Click();
        }

        public void AddEducation()
        {
            #region Add Education
            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileEducation");
            //click on Skill
            EducationTab.Click();
            Thread.Sleep(3000);

            IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= 3; i++)
            {
                //Click on Add New button
                AddNeweducation.Click();
                Thread.Sleep(3000);
                //Enter the University
                EnterUniversity.SendKeys(ExcelLibHelper.ReadData(i + 1, "University"));
                Thread.Sleep(3000);
                //Select the country.
                SelectElement selectcountry = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='country']")));
                selectcountry.SelectByValue(ExcelLibHelper.ReadData(i + 1, "CountryOfCollege"));
                Thread.Sleep(3000);
                //Select the Title
                SelectElement selectTitle = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='title']")));
                selectTitle.SelectByValue(ExcelLibHelper.ReadData(i + 1, "Title"));
                Thread.Sleep(3000);
                //Select the Degree
                Degree.SendKeys(ExcelLibHelper.ReadData(i + 1, "Degree"));
                Thread.Sleep(3000);
                //Select the YearOfPassing
                SelectElement selectYear = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));
                selectYear.SelectByValue(ExcelLibHelper.ReadData(i + 1, "YearOfPassing"));
                Thread.Sleep(3000);
                //Click on Add
                AddEdu.Click();
                Thread.Sleep(3000);
            }
        }
            #endregion
            public void ValidateEducation()
            {
                #region Validate AddEducation
                ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileEducation");

                String ActualEducatn = Driver.driver.FindElement(By.XPath("//td[contains(text(),'B.Tech')]")).Text;
                String ActualUniversity = Driver.driver.FindElement(By.XPath("//td[contains(text(),'University of Queenstown')]")).Text;
                String ExpectedEducatn = ExcelLibHelper.ReadData(2, "Title");
                String ExpectedUniversity = ExcelLibHelper.ReadData(2, "University");


                String ActualEducatn1 = Driver.driver.FindElement(By.XPath("//td[contains(text(),'M.Tech')]")).Text;
                String ActualUniversity1 = Driver.driver.FindElement(By.XPath("//td[contains(text(),'University of Auckland')]")).Text;
                String ExpectedEducatn1 = ExcelLibHelper.ReadData(3, "Title");
                String ExpectedUniversity1 = ExcelLibHelper.ReadData(3, "University");


                String ActualEducatn2 = Driver.driver.FindElement(By.XPath("//td[contains(text(),'B.Sc')]")).Text;
                String ActualUniversity2 = Driver.driver.FindElement(By.XPath("//td[contains(text(),'Cambridge University')]")).Text;
                String ExpectedEducatn2 = ExcelLibHelper.ReadData(4, "Title");
                String ExpectedUniversity2 = ExcelLibHelper.ReadData(4, "University");

                try
                {
                    Thread.Sleep(6000);
                    test = extent.CreateTest("Add Education");

                    if (ActualEducatn == ExpectedEducatn && ActualUniversity == ExpectedUniversity && ActualEducatn1 == ExpectedEducatn1 && ActualUniversity1 == ExpectedUniversity1 && ActualEducatn2 == ExpectedEducatn2 && ActualUniversity2 == ExpectedUniversity2)
                    {
                        Thread.Sleep(3000);
                        test.Log(Status.Pass, "Test Passed, Education Added Successfully");
                        Assert.Pass("Test Passed, Education Added");
                        test.Log(Status.Info, "Validating the Add Education");
                        Thread.Sleep(3000);
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationAddedSuccessfully");

                    }
                    else
                    {
                        Thread.Sleep(3000);
                        test.Log(Status.Fail, "Test Failed, Education not Added");
                        Assert.Fail("Test Fail, Education not Added");
                    }
                }


                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                #endregion

            }

        public void UpdateLanguage()
        {
            #region Update the given Education
            Thread.Sleep(3000);
            // Populate Login page test data collection  
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileEducation");
            String expectedValue = ExcelLibHelper.ReadData(2, "Title");
            //Get the table list
            IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            //Get the row count in table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Title
                String actualValue = Driver.driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                //check if the editLanguage Parameter matches with ith row Title
                if (actualValue.Equals(expectedValue))
                {
                    //CliCk on Edit icon
                    Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[1]/i")).Click();
                    //Send University name to update
                    IWebElement editRowValue = Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    //Clear Previous text 
                    editRowValue.Clear();
                    editRowValue.SendKeys(ExcelLibHelper.ReadData(i + 1, "UpdateUniversity"));
                    // update Country of College
                    SelectElement selectcountry = new SelectElement(Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[1]/div[2]/select")));
                    selectcountry.SelectByValue(ExcelLibHelper.ReadData(i + 1, "UpdateCountryOfCollege"));
                    // update Title
                    SelectElement Title = new SelectElement(Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[1]/select")));
                    Title.SelectByValue(ExcelLibHelper.ReadData(i + 1, "UpdateTitle"));
                    //update the Degree
                    IWebElement EditDegree = Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[2]/input"));
                    // Clear Previous text
                    EditDegree.Clear();
                    EditDegree.SendKeys(ExcelLibHelper.ReadData(i + 1, "UpdateDegree"));
                    //update the Year of Passing.
                    SelectElement selectYear = new SelectElement(Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[3]/select")));
                    selectYear.SelectByValue(ExcelLibHelper.ReadData(i + 1, "UpdateYearOfPassing"));

                    // Click on update button
                    Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[3]/input[1]")).Click();
                    Thread.Sleep(5000);
                }
            }
            #endregion
        }

        public void ValidateUpdatedEducation()
        {
            #region validate updated Education
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileEducation");
            String ActualEducation = Driver.driver.FindElement(By.XPath("//td[contains(text(),'M.B.A')]")).Text;
            String ActualUniversity = Driver.driver.FindElement(By.XPath("//td[contains(text(),'JNTU')]")).Text;
            String ExpectedEducation = ExcelLibHelper.ReadData(2, "UpdateTitle");
            String ExpectedUniversity = ExcelLibHelper.ReadData(2, "UpdateUniversity");
            try
            {
                Thread.Sleep(3000);
                test = extent.CreateTest("Update Education");

                if (ActualEducation == ExpectedEducation && ActualUniversity == ExpectedUniversity)
                {
                    test.Log(Status.Pass, "Test Passed, Education Updated Successfully");
                    Assert.Pass("Test Passed, Education Updated");
                    Thread.Sleep(3000);
                    test.Log(Status.Info, "Validating the Update Education");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationUpdatedSuccessfully");

                }
                else
                {
                    test.Log(Status.Fail, "Test Failed, Education not Updated");
                    Assert.Fail("Test Fail, Education not Updated");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        
        }
        public void DeleteEducation()
        {
            #region Delete given Education
            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileEducation");
            String expectedValue = ExcelLibHelper.ReadData(2, "DeleteUniversity");
            //Get the table row list
            IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                Thread.Sleep(4000);


                //Get the xpath of ith row SkillName
                String actualValue = Driver.driver.FindElement(By.XPath("//div/div[2]/div/table/tbody[" + i + "]/tr/td[2]")).Text;

                //ExtentionBase.WaitForWebElementToExist(Driver.driver, "//div/div[2]/div/table/tbody[" + i + "]/tr/td[2]", "XPath", 5);

                //check if the DeleteSkill parameter matches with ith Row SkillName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[2]/i")).Click();
                    Thread.Sleep(4000);
                    //Driver.wait(5);
                }
            }
            #endregion
        }
        public void ValidateDeleteEducation()
        {
            #region validate Delete Education
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileEducation");
            String ActualUniversity = Driver.driver.FindElement(By.XPath("//td[contains(text(),'JNTU')]")).Text;
            String ExpectedUniversity = ExcelLibHelper.ReadData(2, "DeleteUniversity");
            try
            {
                Thread.Sleep(3000);
                test = extent.CreateTest("Delete Education");

                if (ActualUniversity != ExpectedUniversity)
                {

                    test.Log(Status.Fail, "Test Failed, Education not Deleted");
                    Assert.Fail("Test Fail, Education not Deleted");
                }
                else
                {
                    test.Log(Status.Pass, "Test Passed, Education Delated Successfully");
                    test.Log(Status.Info, "Validating the Delete Education");
                    Thread.Sleep(3000);
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationDeletedSuccessfully");
                    Assert.Pass("Test Passed, Education Deleted");
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