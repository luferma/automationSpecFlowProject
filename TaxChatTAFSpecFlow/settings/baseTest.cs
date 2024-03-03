using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TaxChatTAF.settings
    {
    class BaseTest{
        public IWebDriver  driver;
        [SetUp]
        public void startBrowser(){
            /*
            Selenium driver setup, it's executed before test
             */
            driver = new ChromeDriver("C:\\Users\\um785tm\\OneDrive - EY\\Documents\\entornoTaxChat\\taxchat-test-automation\\TaxChatTAFSpecFlow\\drivers\\chromedriver.exe");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = configConstants.QUALITY_URL;
            driver.Navigate().GoToUrl(configConstants.QUALITY_URL);
        }

        [TearDown]
        public void closeBrowser(){
            /*
            Kill Selenium driver instance after test execution
             */
            driver.Quit();
        }
    }
}