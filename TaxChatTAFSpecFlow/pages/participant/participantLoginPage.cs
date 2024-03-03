using TaxChatTAF.utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TaxChatTAF.pages.documents.signUp;
using NUnit.Framework;
using TaxChatTAFSpecFlow.models;
using System;

namespace TaxChatTAF.pages.participant
{
    class ParticipantLoginPage : SeleniumActions
    {
        By emailParticipant = By.Id("email");
        By passParticipant = By.Id("password");
        By loguinButton = By.Id("submit");
        By discountTitle = By.XPath("//h2");

        public ParticipantLoginPage(IWebDriver driver) {
            this.driver = driver;         
        }

        public void typeParticipantID(string preparerID) 
        {
            IWebElement preparerIDElement = driver.FindElement(emailParticipant);
            preparerIDElement.Clear();
            preparerIDElement.SendKeys(preparerID);
        }

        public void typeParticipantPassword(string preparerPassword)
        {
            IWebElement preparerPasswordElement = driver.FindElement(passParticipant);
            preparerPasswordElement.Clear();
            preparerPasswordElement.SendKeys(preparerPassword);
        }

        public void clickOnSignInButton()
        {            
            waitTillElementIsClickable(loguinButton);
            clickButton(loguinButton);
        }

        public void openParticipantPage()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            List<string> listWindow = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(listWindow[2]);            
            driver.Navigate().GoToUrl(Environment.GetEnvironmentVariable("URL"));
            waitTillPageIsLoaded();
        }        
    }
}
