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
    class Certification
    {
        //Click on CertificateTab
        public IWebElement CertificateTab => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div//form//a[.='Certifications']"));

        //Add new Certificate
        public IWebElement AddNewCerti => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[5]//table//div[.='Add New']"));

        //Enter Certification Name
        public IWebElement EnterCerti => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//input[@name='certificationName']"));

        //Certified from
        public IWebElement CertiFrom => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//input[@name='certificationFrom']"));

        //Year
        public IWebElement CertiYear => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//select[@name='certificationYear']"));

        //Choose Opt from Year
        public IWebElement CertiYearOpt => Driver.driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[2]/div[2]/select/option[5]"));

        //Add Ceritification
        public IWebElement AddCerti => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[5]//input[@value='Add']"));

        //Edit Certificate
        public IWebElement EditCerti => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//table/tbody/tr/td[4]/span[1]/i"));

        // Update Certificate
        public IWebElement UpdateCerti => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//table//input[@value='Update']"));

        //Delete Ceritification
        public IWebElement DeleteCerti => Driver.driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//table/tbody[1]/tr/td[4]/span[2]/i"));

        public void CertiTab()
        {
            CertificateTab.WaitForElementClickable(Driver.driver, 60);
            CertificateTab.Click();
        }

        public void AddCertificate()
        {
            #region Add Certificate

            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileCertificate");

           // CertificateTab.WaitForElementClickable(Driver.driver, 60);
            CertificateTab.Click();


            IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            var rowCount = Tablerows.Count;

            for (int i = 1; i <= 3; i++)
            {
                //Click on Add New button
                AddNewCerti.WaitForElementClickable(Driver.driver, 60);
                AddNewCerti.Click();
                Thread.Sleep(3000);
                // Enter Certificate Name
                EnterCerti.SendKeys(ExcelLibHelper.ReadData(i + 1, "Certificate"));
                // Enter Certified from
                Thread.Sleep(3000);
                CertiFrom.SendKeys(ExcelLibHelper.ReadData(i + 1, "CertifiedFrom"));
                // Select Year
                Thread.Sleep(3000);
                SelectElement year = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name ='certificationYear']")));
                year.SelectByValue(ExcelLibHelper.ReadData(i + 1, "Year"));
                AddCerti.Click();
            }
        }
        #endregion

        public void ValidateAddCertificate()
        {
            #region Validate Add Certificate

            Thread.Sleep(3000);
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileCertificate");
            String ActualCert = Driver.driver.FindElement(By.XPath("//td[contains(text(),'ISTQB')]")).Text;
            String ExpectedCert = ExcelLibHelper.ReadData(2, "Certificate");
            Thread.Sleep(3000);
            String ActualCert1 = Driver.driver.FindElement(By.XPath("//td[contains(text(),'TestAnalyst')]")).Text;
            String ExpectedCert1 = ExcelLibHelper.ReadData(3, "Certificate");

            Thread.Sleep(3000);
            String ActualCert2 = Driver.driver.FindElement(By.XPath("//td[contains(text(),'ScrumMaster')]")).Text;
            String ExpectedCert2 = ExcelLibHelper.ReadData(4, "Certificate");


            try
            {
                Thread.Sleep(3000);
                test = extent.CreateTest("Add Certificate");

                if (ActualCert == ExpectedCert && ActualCert1 == ExpectedCert1 && ActualCert2 == ExpectedCert2)
                {

                    test.Log(Status.Info, "Validating the Add Certificate");
                    Thread.Sleep(3000);
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificateAddedSuccessfully");
                    test.Log(Status.Pass, "Test Passed, Certificate Added Successfully");
                    Assert.Pass("Test Passed, Certificate Added");
                }
                else
                {
                    test.Log(Status.Fail, "Test Failed, Certificate not Added ");
                    Assert.Fail("Test Fail, Certificate not Added");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            #endregion

        }


        public void UpdateCertificate()
        {
            #region Update Certificate
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileCertificate");
            //click on Skill
            EditCerti.WaitForElementClickable(Driver.driver, 60);
            EditCerti.Click();
            Thread.Sleep(3000);
            // Enter Certificate Name
            EnterCerti.Clear();
            EnterCerti.SendKeys(ExcelLibHelper.ReadData(2, "UpdateCertificate"));
            // Enter Certified from
            Thread.Sleep(3000);
            CertiFrom.Clear();
            CertiFrom.SendKeys(ExcelLibHelper.ReadData(2, "UpdateCertifiedFrom"));
            // Select Year
            Thread.Sleep(3000);
            SelectElement year = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name ='certificationYear']")));
            year.SelectByValue(ExcelLibHelper.ReadData(2, "UpdateYear"));
            UpdateCerti.WaitForElementClickable(Driver.driver, 60);
            UpdateCerti.Click();
            Thread.Sleep(4000);
            #endregion
        }
        public void ValidateUpdateCertificate()
        {

            #region Validate Update Certificate


            Thread.Sleep(3000);
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileCertificate");
            String ActualCert = Driver.driver.FindElement(By.XPath("//td[contains(text(),'ISTQBExpert')]")).Text;
            String ExpectedCert = ExcelLibHelper.ReadData(2, "UpdateCertificate");


            try
            {
                Thread.Sleep(3000);
                test = extent.CreateTest("Update Certificate");

                if (ActualCert == ExpectedCert)
                {

                    test.Log(Status.Info, "Validating the Update Certificate");
                    Thread.Sleep(3000);
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificateUpdatedSuccessfully");
                    test.Log(Status.Pass, "Test Passed, Certificate Updated Successfully");
                    Assert.Pass("Test Passed, Certificate Updated");
                }
                else
                {
                    test.Log(Status.Fail, "Test Failed, Certificate not Updated ");
                    Assert.Fail("Test Fail, Certificate not Updated");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
        }

        public void DeleteCertificate()
        {
            #region Delete given Education
            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileCertificate");
            String expectedValue = ExcelLibHelper.ReadData(2, "DeleteCertificate");
            //Get the table row list
            IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                Thread.Sleep(4000);


                //Get the xpath of ith row SkillName
                String actualValue = Driver.driver.FindElement(By.XPath("//div/div[2]/div/table/tbody[" + i + "]/tr/td[2]")).Text;

                WaitExtentions.ElementIsVisible(Driver.driver, "//div/div[2]/div/table/tbody[" + i + "]/tr/td[2]", "XPath", 5);

                //check if the DeleteSkill parameter matches with ith Row SkillName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[2]/i")).Click();
                    Thread.Sleep(4000);
                    Driver.wait(5);
                }
            }
            #endregion

        }

        public void ValidateDeleteCertificate()
        {
                #region validate Delete Certificate
                ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ProfileCertificate");
                Thread.Sleep(3000);
                String ActualCertificate = Driver.driver.FindElement(By.XPath("//td[contains(text(),'ISTQBExpert')]")).Text;
                Thread.Sleep(3000);
                String ExpectedCertificate = ExcelLibHelper.ReadData(2, "DeleteCertificate");
                try
                {
                    Thread.Sleep(3000);
                    test = extent.CreateTest("Delete Certificate");

                    if (ActualCertificate != ExpectedCertificate)
                    {

                        test.Log(Status.Fail, "Test Failed, Certificate not Deleted");
                        Assert.Fail("Test Fail, Certificate not Deleted");
                    }
                    else
                    {
                        test.Log(Status.Pass, "Test Passed, Certificate Delated Successfully");
                        test.Log(Status.Info, "Validating the Delete Certificate");
                        Thread.Sleep(3000);
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificateDeletedSuccessfully");
                        Assert.Pass("Test Passed, Certificate Deleted");
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

