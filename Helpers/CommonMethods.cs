using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_1.Helpers
{
    
        public class CommonMethods
        {
            //Screenshots
            //Screenshot

            public class SaveScreenShotClass
            {

                public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
                {
                    var folderLocation = (ConstantHelpers.ScreenshotPath);

                    if (!System.IO.Directory.Exists(folderLocation))
                    {
                        System.IO.Directory.CreateDirectory(folderLocation);
                    }

                    var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                    var fileName = new StringBuilder(folderLocation);

                    fileName.Append(ScreenShotFileName);
                    fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                    //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
                    fileName.Append(".jpeg");
                    screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                    return fileName.ToString();
                }
            }

        //ExtentReports
        //ExtentReports
        //ExtentReports
        #region reports
        public static string ReportPath;
        public static string ReportXMLPath;
        public static ExtentTest test;
        public static ExtentReports extent;


        #endregion
        

        // private static ExtentHtmlReporter htmlReporter;

        /* public static void ExtentReports()
         {
            /* if (extent == null)
             {
                 string reportPath = ConstantHelpers.ReportPath;
                 string reportFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(".", "_");
                 htmlReporter = new ExtentHtmlReporter(reportPath + reportFile);
                 extent = new ExtentReports();
                 extent.AttachReporter(htmlReporter);
                 extent.AddTestRunnerLogs(reportPath + "Extent Config.xml");
             }
              extent = new ExtentReports(ConstantHelpers.ReportPath, true, DisplayOrder.NewestFirst);
             extent.LoadConfig(ConstantHelpers.ReportXMLPath);
         }*/



    }







}

