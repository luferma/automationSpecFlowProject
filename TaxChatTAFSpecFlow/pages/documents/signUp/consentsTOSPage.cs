using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TaxChatTAFSpecFlow.models;
using TaxChatTAFSpecFlow.utils;

namespace TaxChatTAF.pages.documents.signUp
{
    class ConsentsTOSPage : SignUpPage
    {
        By taxPayersName = By.Id("answer-2");
        By todaysDate = By.CssSelector("div.DayPickerInput > input");
        By todaysDateContainer = By.ClassName("DayPickerInput");
        By spouseFirstNameField = By.Id("answer-5");
        By spouseLastNameField = By.Id("answer-14");
        By yesAnswerRadioButton = By.Id("input-4-My answer is “Yes” to one or more of the above questions");
        By noAnswerRadioButtonOld = By.Id("input-4-My answer is “No” to all of the above questions");
        By noAnswerRadioButton = By.XPath("//input[contains(@id,'to all of the above questions')]");
        By finantialReportingYesRadioButton = By.Id("input-5-Yes (or unsure)");
        By finantialReportingNoRadioButton = By.Id("input-5-No");
        By emailSpouse = By.XPath("//input[contains(@placeholder,'Spouse email')]");

        public ConsentsTOSPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public void typeTaxPayerName(string taxPayerName)
        {
            IWebElement taxPayersNameElement = driver.FindElement(taxPayersName);
            taxPayersNameElement.Clear();
            taxPayersNameElement.SendKeys(taxPayerName);
        }

        public void setTodayDate(string todayDate)
        {
            IWebElement datePicker = driver.FindElement(todaysDate);
            datePicker.SendKeys(todayDate);
            driver.FindElement(todaysDateContainer).Click();
        }

        public void typeSpouseFirstName(string spouseFirstname) 
        {
            IWebElement spouseFirstNameElement = driver.FindElement(spouseFirstNameField);
            spouseFirstNameElement.Clear();
            spouseFirstNameElement.SendKeys(spouseFirstname);
        }

        public void typeSpouseLastName(string spouseLastName)
        {
            IWebElement spouseLastNameElement = driver.FindElement(spouseLastNameField);
            spouseLastNameElement.Clear();
            spouseLastNameElement.SendKeys(spouseLastName);
        }

        public void selectYesAnswerToReportableTransaction() 
        {
            selectRadioButton(yesAnswerRadioButton);
        }

        public void selectNoAnswerToReportableTransaction()
        {
            selectRadioButton(noAnswerRadioButton);
        }

        public void openPreparerPage(ParticipantData participant) 
        {           
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            List<string> listWindow = new List<string>(driver.WindowHandles);

            if (participant.isCreatedUser.Equals("No"))
            {
                driver.SwitchTo().Window(listWindow[3]);
            }
            else
            {
                driver.SwitchTo().Window(listWindow[1]);
            }
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90); 
            try
            {
                driver.Navigate().GoToUrl(Environment.GetEnvironmentVariable("PREPARER_URL"));
            }
            catch (Exception)
            {
                driver.Navigate().Refresh();
            }
            driver.Navigate().Refresh();
            waitTillPageIsLoaded();
        }

        public void selectYesAnswerInFinantialReporting() 
        {
            selectRadioButton(finantialReportingYesRadioButton);
        }
        public void selectNoAnswerInFinantialReporting()
        {
            selectRadioButton(finantialReportingNoRadioButton);
        }

        public void typeEmailSpouse(string emailSpouseSend)
        {            
            sendValue(emailSpouseSend, emailSpouse);            
        }
    }
}
