using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Reflection;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using TaxChatTAF;
using TaxChatTAFSpecFlow.utils;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using BDDSelenium.driver;

namespace SpecflowParallelTest
{
    [Binding]
    public class Hooks
    {
        //Global Variable for Extend report
        private static AventStack.ExtentReports.ExtentReports extent;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentTest node;
        
        // public property is accessible from other classes       
        private readonly IObjectContainer _objectContainer;

        private RemoteWebDriver _driver;
        string fileCopyReport = Utilities.getRelativePathRoute(configConstants.ROUTE_REPORT_COPY_AUTOMATION);

        [BeforeTestRun]
        public static void InitializeReport()
        {
            string fileLocation = Utilities.getRelativePathRoute(configConstants.ROUTE_REPORT_AUTOMATION);
            var htmlReporter = new ExtentHtmlReporter(fileLocation);            
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);

            /*Environment.SetEnvironmentVariable("URL", configConstants.DEV_URL);
            Environment.SetEnvironmentVariable("PREPARER_URL", configConstants.PREPARER_URL_DEV);
            Environment.SetEnvironmentVariable("PREPARER_USER", configConstants.PREPARER_USER_DEV);
            Environment.SetEnvironmentVariable("PREPARER_PASS", configConstants.PREPARER_PASS_DEV);*/

            Environment.SetEnvironmentVariable("URL", configConstants.QUALITY_URL);
            Environment.SetEnvironmentVariable("PREPARER_URL", configConstants.PREPARER_URL_Q);
            Environment.SetEnvironmentVariable("PREPARER_USER", configConstants.PREPARER_USER_Q);
            Environment.SetEnvironmentVariable("PREPARER_PASS", configConstants.PREPARER_PASS_Q);

            /*Environment.SetEnvironmentVariable("URL", configConstants.UAT_URL);
            Environment.SetEnvironmentVariable("PREPARER_URL", configConstants.PREPARER_URL_UAT);
            Environment.SetEnvironmentVariable("PREPARER_USER", configConstants.PREPARER_USER_UAT);
            Environment.SetEnvironmentVariable("PREPARER_PASS", configConstants.PREPARER_PASS_UAT);*/

            string fileCopyReport = Utilities.getRelativePathRoute(configConstants.ROUTE_REPORT_COPY_AUTOMATION);
            string createDirectory = fileCopyReport + "screenshots";
            Directory.CreateDirectory(createDirectory);

        }
        
        public Hooks(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;
        }
        
        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();            
            string time = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string fileCopyReport = Utilities.getRelativePathRoute(configConstants.ROUTE_REPORT_COPY_AUTOMATION);
            string createDirectory = fileCopyReport + "Report_" + time;
            if (!(Directory.Exists(createDirectory)))
            {
                Directory.CreateDirectory(createDirectory);
            }            
            string sourceFileDashboard = fileCopyReport + "dashboard.html";
            string sourceFileIndex = fileCopyReport + "index.html";
            string destFileDashboard = createDirectory + "\\" + "dashboard.html";
            string destFileIndex = createDirectory + "\\" + "index.html";

            System.IO.File.Copy(sourceFileDashboard, destFileDashboard, true);
            System.IO.File.Copy(sourceFileIndex, destFileIndex, true);
            System.IO.Directory.Move(fileCopyReport + "screenshots", createDirectory + "\\" + "screenshots");            
        }
        
        [BeforeFeature]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            DateTime now = DateTime.Now;
            string screenShotPath;           

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                {
                    node = scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    try
                    {
                        if (ScenarioStepContext.Current.StepInfo.Text.Equals("He fills out the fields related to tax situation"))
                        {
                            var tile = (string)ScenarioContext.Current["tile"];
                            var internalOption = (string)ScenarioContext.Current["internal_option"];
                            var input = (int)ScenarioContext.Current["input"];
                            var isValidationSpigotGroup = (string)ScenarioContext.Current["isValidationSpigotGroup"];
                            var isValidationTileByParts = (string)ScenarioContext.Current["isValidationTileByParts"];
                            var emailPattern = (string)ScenarioContext.Current["emailPattern"];
                            var tileList = (List<string>)ScenarioContext.Current["tileList"];                            
                            List<string> tileListCycle = tileList;
                            node = scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text + ": ");
                            if (String.Equals(isValidationSpigotGroup, "Yes"))
                            {
                                node.Log(Status.Info, "Tile: Complete" + " -- Input: " + input + " -- Email pattern: " + emailPattern);
                                
                            }
                            else
                            {                               
                                foreach (string tileIter in tileListCycle)
                                {
                                    node.Log(Status.Info, "Tile: " + tileIter + " -- Input: " + input + " -- Internal option: " + (isValidationTileByParts == "Yes" ? "Complete" : internalOption));
                                }
                            }
                            var emailVar = (string)ScenarioContext.Current["email"];
                            var passwordVar = (string)ScenarioContext.Current["password"];
                            node.Log(Status.Info, "Email: " + emailVar);
                            node.Log(Status.Info, "Password: " + passwordVar);
                        }else if (ScenarioStepContext.Current.StepInfo.Text.Equals("The user declines the terms of use"))
                        {
                            node = scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                            var emailVar = (string)ScenarioContext.Current["email"];
                            var passwordVar = (string)ScenarioContext.Current["password"];
                            node.Log(Status.Info, "Email: " + emailVar);
                            node.Log(Status.Info, "Password: " + passwordVar);
                        } else
                        {
                            node = scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                        }
                    }
                    catch (Exception)
                    {
                        node = scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    }
                }
                else if (stepType == "Then")
                {
                    if (ScenarioStepContext.Current.StepInfo.Text.Equals("The user should see the correct complexity"))
                    {
                        node = scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                        int quoteValidate = (int)ScenarioContext.Current["quoteValidate"];
                        string complexityValidate = (string)ScenarioContext.Current["complexityValidate"];
                        string discountType = (string)ScenarioContext.Current["discountType"];
                        int quoteWithoutDiscount = (int)ScenarioContext.Current["quoteWithoutDiscount"];
                        int discountValue = (int)ScenarioContext.Current["discountValue"];
                        node.Log(Status.Info, "Quote without discount: " + quoteWithoutDiscount);
                        node.Log(Status.Info, "Type of discount: " + discountType);
                        node.Log(Status.Info, "Value of the discount: " + discountValue);
                        node.Log(Status.Info, "Quote to validate: " + quoteValidate);
                        node.Log(Status.Info, "Complexity to validate: " + complexityValidate);
                        
                    }
                    else
                    {
                        node = scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                    }
                }
                else if (stepType == "And")
                {
                    
                    node = scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);                        
                    
                }
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                {
                    failStepUtility(scenario, node, "Given ");                    
                }
                else if (stepType == "When")
                {
                    failStepUtility(scenario, node, "When ");                   
                }
                else if (stepType == "Then")
                {
                    failStepUtility(scenario, node, "Then ");                    
                }
                else if (stepType == "And")
                {
                    failStepUtility(scenario, node, "And ");                    
                }
            }
        }
       
        [BeforeScenario]
        public void Initialize()
        {                        
            _driver = DriverFactory.CreateDriver(configConstants.DRIVER_CHROME);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = Environment.GetEnvironmentVariable("URL");            
            _driver.Navigate().GoToUrl(Environment.GetEnvironmentVariable("URL"));
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            UtilitiesHooks.manageCookies(_driver);
            //Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void CleanUp()
        {
            extent.Flush();
            _driver.Quit();
            DisposeDriverService.FinishHim(_driver);
        }

        public void failStepUtility(ExtentTest scenario, ExtentTest node, string stepType)
        {
            string screenShotPath;
            DateTime now = DateTime.Now;
            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(ScenarioContext.Current.TestError.Message + " -- " + ScenarioContext.Current.TestError.InnerException + " -- " + ScenarioContext.Current.TestError.Data + " -- " + ScenarioContext.Current.TestError.StackTrace);
            screenShotPath = GetScreenShot.Capture(_driver, stepType + now);
            node.Log(Status.Fail, "Test fail", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
        }
    }
}
