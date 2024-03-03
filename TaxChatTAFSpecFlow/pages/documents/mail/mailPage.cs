using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using TaxChatTAF.utils;
using TaxChatTAFSpecFlow.utils;

namespace TaxChatTAF.pages.documents.popups
{
    class MailPage : SeleniumActions
    {
        By inbox = By.XPath("//a[@title='Inbox']");
        By emailField = By.Id("identifierId");
        By passwordField = By.XPath("//div[@id='password']//input");
        By nextEmailField = By.XPath("//div[@id='identifierNext']//span[contains(text(),'Siguiente')]");
        By nextPasswordField = By.XPath("//div[@id='passwordNext']//span[contains(text(),'Siguiente')]");
        By popUp = By.XPath("//div[@class='bBf']");
        By searchBar = By.XPath("//input[@placeholder='Search mail']");
        By searchPopUp = By.XPath("//span[@class='bAq']");
        By searchButton = By.XPath("//button[@aria-label='Search mail' and @role='button']");
        By searchResult = By.XPath("(//td[@role='gridcell']//span[@class='bA4']//span[contains(@name,'EY TaxChat')])[2]");
        By searchResult2 = By.XPath("(//td[@role='gridcell']//span[@class='bA4']//span[contains(@name,'EY TaxChat')])[4]");
        By searchResult3 = By.XPath("//div[contains(@role,'main')]//div[contains(@jsaction,'CLIENT')]");
        By linkConfirmed = By.XPath("//a[contains(@data-saferedirecturl,'confirmed')]");
        By noResults = By.XPath("//div[@class='bc2']");
        By buttonContinueConfirmation = By.XPath("//button[@id='submit']");
        By emailParticipant = By.Id("email");
        By passParticipant = By.Id("password");
        By loguinButton = By.Id("submit");
        By licenseIcon = By.XPath("//div[contains(text(),'Valid state')]");
        By deleteEmail = By.XPath("(//div[@aria-label='Delete'])[2]");
        By deleteEmail2 = By.XPath("//div[@aria-label='Delete']//div[@class='asa']");
        By titleEmail = By.XPath("//h2//span[text()='Confirm']");
        By groupMenuGmail = By.XPath("//div[@class='iH bzn']//div[@class='G-tF']//div[2][@class='G-Ni G-aE J-J5-Ji']");
        By containerParticipant = By.XPath("col - main Message--container");
        By allSetText = By.XPath("//h1[contains(text(),'All Set')]");
        By noResultsSearch = By.XPath("//td[contains(text(),'No messages matched your search')]");


        public MailPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickOnInbox()
        {
            IWebElement inboxElement = getEnableElement(inbox);
            inboxElement.Click();
        }

        public void typeEmail(string email)
        {
            IWebElement emailFieldElement = driver.FindElement(emailField);
            emailFieldElement.SendKeys(email);
        }

        public void typePassword(string password)
        {
            IWebElement passwordFieldElement = driver.FindElement(passwordField);
            passwordFieldElement.SendKeys(password);
        }

        public void clickOnNextButtonEmail()
        {
            IWebElement nextButtonelement = waitTillElementIsClickable(nextEmailField);
            nextButtonelement.Click();
            waitTillPageIsLoaded();
        }

        public void clickOnNextButtonPassword()
        {
            IWebElement nextButtonelement = waitTillElementIsClickable(nextPasswordField);
            nextButtonelement.Click();
            waitTillPageIsLoaded();
        }

        public void waitTillEmailTitleIsDisplayedVoid()
        {
            waitTillElementIsDisplayedVoid(titleEmail, 20);
        }

        public void waitTillSearchBarIsDisplayedVoid()
        {
            waitTillElementIsClickableWithTime(searchBar, 50);
        }

        public void searchMail(string name, string lastname, string isB2B2CUser)
        {                       
            try
            {
                waitForLoadWithTime(driver);
            }
            catch (Exception)
            {
                driver.Navigate().Refresh();
            }
                       
            waitTillElementIsDisplayed(searchBar);
            waitTillElementIsClickable(searchButton);

            UtilitiesHooks.updateCookieFile(driver);

            IWebElement emailSearch = waitTillElementIsDisplayed(searchBar);            
            IWebElement buttonSearch = driver.FindElement(searchButton);
         
            scrollMoveElementJavaScript(searchBar);
            emailSearch.SendKeys("in:inbox is:unread subject:Confirm your email to:" + name + " " + lastname);            
            
            buttonSearch.Click();
            
            Boolean continueCycle = true;
            Boolean emailFound = true;
            DateTime date1 = DateTime.UtcNow;
            while (continueCycle)
            {
                try
                {
                    IWebElement resultSearch = driver.FindElement(noResultsSearch);
                    DateTime date2 = DateTime.UtcNow;
                    TimeSpan timeDifference = date1.Subtract(date2);
                    if (resultSearch.Displayed)
                    {
                        continueCycle = true;
                        clickButton(searchButton);
                        buttonSearch.Click();
                    }
                    else
                    {
                        continueCycle = false;
                        resultSearch = driver.FindElement(noResultsSearch);
                    }
                    if((timeDifference.TotalSeconds * -1) > 60)
                    {
                        continueCycle = false;
                        emailFound = false;
                    }
                }
                catch (Exception)
                {
                    continueCycle = false;                    
                }
            }
            Assert.AreEqual(true, emailFound);
            IWebElement resultSearchOk = waitTillElementIsClickableWithTime(searchResult3, 5);
            resultSearchOk.Click();            
            
            string linkConfirmedString;
            try
            {                
                linkConfirmedString = getAttributeLinkConfirmed();
            }
            catch (Exception)
            {               
                linkConfirmedString = getAttributeLinkConfirmed();
            }
            
            try
            {                
                clickConfirmedLink();
            }
            catch (Exception)
            {                
                clickConfirmedLink();
            }

            refreshURLConfirmed(linkConfirmedString, isB2B2CUser);
        }

        public void refreshURLConfirmed(string linkConfirmedString, string isB2B2CUser)
        {
            List<string> listWindow = new List<string>(driver.WindowHandles);
            string tab = "2";
            if (isB2B2CUser.Equals("No"))
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
                listWindow = new List<string>(driver.WindowHandles);
                driver.SwitchTo().Window(listWindow[1]);
                driver.Navigate().GoToUrl(linkConfirmedString);
                waitTillPageIsLoaded();
                tab = "1";
            }            
            openUrlAndRefresh(driver, linkConfirmedString, listWindow, tab);

            Boolean continueRefresh = true;
            IWebElement resultSearch;
            while (continueRefresh)
            {
                try
                {
                    resultSearch = waitTillElementIsDisplayedWithTime(allSetText, 10);
                    if (resultSearch.Displayed)
                    {
                        continueRefresh = false;
                    }
                    else
                    {
                        continueRefresh = true;
                        openUrlAndRefresh(driver, linkConfirmedString, listWindow, tab);                        
                    }
                }
                catch (Exception)
                {
                    continueRefresh = true;
                    openUrlAndRefresh(driver, linkConfirmedString, listWindow, tab);
                }
            }

            IWebElement buttonContinueConfirmationClick = waitTillElementIsClickableWithTime(buttonContinueConfirmation, 20);
            buttonContinueConfirmationClick.Click();

            if (isB2B2CUser.Equals("Yes"))
            {
                driver.SwitchTo().Window(listWindow[1]);
                driver.Navigate().Refresh();
                scrollMoveElement(groupMenuGmail);
                IWebElement deleteEmailClick = waitTillElementIsClickableWithTime(deleteEmail2, 15);
                deleteEmailClick.Click();
                driver.SwitchTo().Window(listWindow[2]);
            }
        }
        
        public void openUrlAndRefresh(IWebDriver driver, string linkConfirmedString, List<string> listWindow, string tab)
        {
            driver.SwitchTo().Window(listWindow[Int32.Parse(tab)]);
            driver.Navigate().GoToUrl(linkConfirmedString);
            driver.Navigate().Refresh();
        }
        
        public void clickConfirmedLink()
        {
            IWebElement linkConfirmedClick = waitTillElementIsDisplayedWithTime(linkConfirmed, 15);
            linkConfirmedClick.Click();
        }

        public string getAttributeLinkConfirmed()
        {
            IWebElement linkGetHref = waitTillElementIsDisplayedWithTime(linkConfirmed, 15);
            string linkConfirmedString = linkGetHref.GetAttribute("href");
            return linkConfirmedString;
        }
        
    }
}